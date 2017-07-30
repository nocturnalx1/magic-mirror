﻿using System;
using MagicMirror.DataAccess.Entities;
using System.Threading.Tasks;
using MagicMirror.DataAccess;
using MagicMirror.Entities.Traffic;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Repos;

namespace MagicMirror.Business.Services
{
    public class TrafficService : ServiceBase, IService<TrafficModel>
    {
        private readonly IRepo<TrafficEntity> _repo;

        public TrafficService()
        {
            var criteria = new SearchCriteria
            {
                Start = "Heikant 51 3390 Houwaart",
                Destination = "Generaal ArmstrongWeg 1 Antwerpen"
            };

            _repo = new TrafficRepo(criteria);
        }

        public async Task<TrafficModel> GetModelAsync()
        {
            // Get entity from repository
            TrafficEntity entity = await _repo.GetEntityAsync();

            // Map entity to model
            TrafficModel model = MapEntityToModel(entity);

            // Calculate non-mappable values
            model = CalculateMappedValues(model);

            return model;
        }

        public TrafficModel CalculateMappedValues(TrafficModel model)
        {
            model.Minutes = (model.Minutes / 60);
            model.TrafficDensity = CalculateTrafficDensity(model.NumberOfIncidents);
            model.HourOfArrival = DateTime.Now.AddMinutes(model.Minutes);

            return model;
        }

        private TrafficDensity CalculateTrafficDensity(int numberOfIncidents)
        {
            if (numberOfIncidents < 0) throw new ArgumentException("Number of incidents cannot be a negative number");

            TrafficDensity result;

            if (numberOfIncidents == 0)
            {
                result = TrafficDensity.Few;
            }
            else if (numberOfIncidents <= 1)
            {
                result = TrafficDensity.Light;
            }
            else if(numberOfIncidents <= 2)
            {
                result = TrafficDensity.Medium;
            }
            else
            {
                result = TrafficDensity.Heavy;
            }

            return result;
        }

        public TrafficModel MapEntityToModel(Entity entity)
        {
            TrafficModel model = Mapper.Map<TrafficModel>(entity);
            return model;
        }
    }
}