using P.IRepo;
using P.Models;

namespace P.Repo
{
    public class MedicalRecordRepo : IMedicalRecord
    {
        private readonly HospitalContext context;

        public MedicalRecordRepo(HospitalContext context)
        {
            this.context = context;
        }

        public List<MedicalRecord> GetAll()
        {
           return context.MedicalRecords.ToList();
        }

        public MedicalRecord GetByID(int id)
        {
            return context.MedicalRecords.FirstOrDefault(m => m.RecordId == id);
        }

        public void Insert(MedicalRecord record)
        {
            context.MedicalRecords.Add(record);
            context.SaveChanges();
        }

        public void Update(int id, MedicalRecord newmed)
        {
            MedicalRecord olmed = GetByID(id);
            olmed.PatientName = newmed.PatientName;
            olmed.DateOfBirth = newmed.DateOfBirth;
            olmed.Gender = newmed.Gender;
            olmed.PatientMedicalHistory = newmed.PatientMedicalHistory;
            olmed.Medications = newmed.Medications;
            olmed.Diagnosis = newmed.Diagnosis;
            olmed.TestResults = newmed.TestResults;
            olmed.ProgressNotes = newmed.ProgressNotes;
            olmed.TreatmentPlans = newmed.TreatmentPlans;
            olmed.VitalSigns = newmed.VitalSigns;
            olmed.SurgicalReports = newmed.SurgicalReports;
            olmed.DischargeSummaries = newmed.DischargeSummaries;
            context.SaveChanges();
        }

      public void Delete (int id)
        {
            MedicalRecord medical = GetByID(id);
            context.MedicalRecords.Remove(medical);
            context.SaveChanges();
        }
    }
}
