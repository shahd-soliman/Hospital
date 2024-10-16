using Hospital.IRepo;
using Microsoft.EntityFrameworkCore;
using P.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Repo
{
    public class PatientRepo : IPatient
    {
        HospitalContext context = new HospitalContext();
        

        public int P_ID { get; set; }

        public PatientRepo()
        {}

        public List<Patient> GetAll()
        {

            return context.Patients.ToList();
        }

        public Patient GetById(int  id)
        {
            Patient patient = context.Patients.FirstOrDefault(e => e.PId == id);
            return patient;
        }

        public void Update(int id, Patient patient)
        {
           
            Patient oldPatient = GetById(id);
                oldPatient.F_Name = patient.F_Name;
                oldPatient.L_Name = patient.L_Name;
                oldPatient.Address = patient.Address;
                oldPatient.RoomId = patient.RoomId;
                oldPatient.Age = patient.Age;
                oldPatient.Phone = patient.Phone;
                context.SaveChanges();
        }

        public void Insert(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Patient patient = GetById(id);
            if (patient != null) {
            context.Patients.Remove(patient);
            context.SaveChanges();
                }
        }
    }
}
