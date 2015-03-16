
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;
using PatientData.Models;

namespace PatientData
{
    public  static class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();
            if (!patients.AsQueryable().Any(p => p.Name == "Scott"))
            {
                var data = new List<Patient>(){
                    new Patient{ Name="Scott", 
                                 Ailments= new List<Ailment>(){new Ailment(){ Name ="CrazyAilment"}}, 
                                 Medications = new List<Medication>(){ new Medication(){ Name = "CrazyMedication"}}},
                    new Patient{ Name="Joy", 
                                 Ailments= new List<Ailment>(){new Ailment(){ Name ="CrazyAilment"}}, 
                                 Medications = new List<Medication>(){ new Medication(){ Name = "CrazyMedication"}}},
                    new Patient{ Name="Sarah", 
                                 Ailments= new List<Ailment>(){new Ailment(){ Name ="CrazyAilment"}}, 
                                 Medications = new List<Medication>(){ new Medication(){ Name = "CrazyMedication"}}},
                };
                patients.InsertBatch(data);
            }
        }
    }
}