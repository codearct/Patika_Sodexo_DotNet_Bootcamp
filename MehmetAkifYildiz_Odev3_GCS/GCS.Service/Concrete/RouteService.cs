using AutoMapper;
using GCS.Repository.Abstract;
using GCS.Service.Abstract;
using GCS.Service.DTO.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Service.Concrete
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        //Inject dependencies
        public RouteService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public IEnumerable<List<QueryContainerDto>> AssignRoute(long vehicleId, int NumOfClusters)
        {
            //Get all containers according to vehicle id
            var containers = _uow.Containers.GetAllByVehicleId(vehicleId);
            //Assign containers latitude and longitude to nested array
            var coordinates = Enumerable
                                    //Start loop from zero to length of container list 
                                    .Range(0, containers.Count)
                                    //Create an array for container's latitude and longitude and assign to one item of loop
                                    .Select(i => new[] { containers[i].Latitude, containers[i].Longitude })
                                    //Assign each array of a container coordinate to parent array
                                    .ToArray();
            //Create random class having exact seed(1)
            var rnd = new Random(1);
            //Assign randomly all containers coordinates to lists as tuple
            var randomAssignedClusters = Enumerable
                                    //Start loop from zero to length of coordinates list
                                    .Range(0, coordinates.Length)
                                    //Create a tuple having two items for each item loop
                                    //.Assign coordinates as values to assignedCLuster as random value for each item loop 
                                    .Select(i => (assignedCluster: rnd.Next(0, NumOfClusters), values: coordinates[i]))
                                    //Assign these tuples to a list
                                    .ToList();
            //Take 2d or 3d dimension that 2d in our case 
            int dimension = coordinates[0].Length;
            //Describe a limit for while loop for checking cluster changes
            var limit = 10000;
            //Status cluster changes
            var isChanged = true;
            //Change random assigned cluster to exact route according to distance between centroid points and  container coordinates distance
            while (--limit > 0)
            {
                //Find centroids for random assigned clusters
                var centroids = Enumerable
                                //Star loop
                                .Range(0, NumOfClusters)
                                //Do parallel thread for queries
                                .AsParallel()
                                //Take index number
                                .Select(
                                    //ClusterNo as index
                                    //Create tuple having items as cluster and centerPoint
                                    clusterNo => (cluster: clusterNo,
                                                centerPoint: Enumerable
                                                            //Start nested loop from zero to 2 dimension for x and y
                                                            .Range(0, dimension)
                                                            //Select random assigned cluster according to equality between assignedCluster and clusterNo
                                                            .Select(axis => randomAssignedClusters.Where(s => s.assignedCluster == clusterNo)
                                                            //Count average of coordinates points in selected cluster 
                                                            .Average(s => s.values[axis]))
                                                            //Add an array these averages
                                                            .ToArray()));

                //Change status of clusters relations each other as false
                isChanged = false;
                //By distance between points and their center,change the point which cluster belongs to inside paralel iterations
                Parallel.For(0, randomAssignedClusters.Count, i =>
                {
                    //Select cluster by index 
                    var singleAssignedCluster = randomAssignedClusters[i];
                    //Assign it this cluster as old one
                    var oldAssignedCluster = singleAssignedCluster.assignedCluster;
                    //by distance between points and their center,change cluster as a new one
                    var newAssignedCluster = centroids.Select(c =>
                                                                  (clusterNo: c.cluster,
                                                                  //Count distance between points and their cluster which have points center
                                                                  distance: distanceOfPoints(singleAssignedCluster.values, c.centerPoint)))
                                                       //Sort by distance
                                                       .OrderBy(nac => nac.distance)
                                                       //Select closest point to center
                                                       .First()
                                                       //Change its cluster
                                                       .clusterNo;

                    //Continue if new cluster and old cluster are not equal to each other
                    if (newAssignedCluster != oldAssignedCluster)
                    {
                        randomAssignedClusters[i] = (assignedCluster: newAssignedCluster, values: singleAssignedCluster.values);
                        isChanged = true;
                    }
                });
                //Break while loop if clusters status do not change anymore
                //And break while loop when loop equals to zero not matter status change or not
                if (!isChanged)
                {
                    break;
                }
            }
            //Find containers not points by new clusters situation
            var newContainers = Enumerable
                                    //Star loop
                                    .Range(0, (int)NumOfClusters)
                                    //Select the cluster by index number that equals to its assignedCluster number
                                    .Select(i => randomAssignedClusters.Where(rac => rac.assignedCluster == i)
                                                                        //Select that cluster's values that means coordinates
                                                                        .Select(rac => rac.values)
                                                                            //Change points with their containers
                                                                            .Select(v => containers
                                                                                                .Where(c => c.Latitude == v[0] && c.Longitude == v[1])
                                                                                                .SingleOrDefault())
                                                                        //Add containers to a new list
                                                                        .ToList());
            //Map Container Class to QueryContainerDto
            IEnumerable<List<QueryContainerDto>> containerDtos = _mapper.Map<IEnumerable<List<QueryContainerDto>>>(newContainers);
            //Return that DTO as result
            return containerDtos;
        }
        //Count distance between two decimal point array
        internal decimal distanceOfPoints(decimal?[] points1, decimal?[] points2)
        {
            var distance = points1.Zip(
                          points2, (n1, n2) =>
                          (decimal)Math.Pow((double)(n1 - n2), (double)2)).Sum();

            return (decimal)Math.Sqrt((double)distance);
        }
    }
}
