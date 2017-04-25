using EntityDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityDatabase.Repository.Operation;
using EntityDatabase.Models;

namespace MPocket.Models
{
    public class SettingsModel
    {
        public int Id { get; set; }
        public bool IsManual { get; set; }
        public int UserId { get; set; }

        public void AddSettings(SettingsModel model)
        {
            //Settings settings = AutoMapper.Mapper.Map<SettingsModel, Settings>(model);
            Settings settings = new Settings();
            settings.IsManual = model.IsManual;
            settings.UserId = model.UserId;

            using (var c = new EntityContext())
            {
                SettingsOperation operation = new SettingsOperation();
                operation.Add(settings, c);
            }
        }
    }
}