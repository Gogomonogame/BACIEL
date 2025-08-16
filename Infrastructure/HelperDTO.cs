using College.Domain.Entities;
using College.Models;


namespace College.Infrastructure
{
    public static class HelperDTO
    {
        public static GroupDTO TransformGroup(Group entity)
        {
            GroupDTO entityDTO = new GroupDTO();
            entityDTO.Id = entity.Id;
            entityDTO.GroupName = entity.GroupName;
            entityDTO.Speciality = entity.Speciality;
            entityDTO.Course = entity.Course;
            return entityDTO;
        }
        public static IEnumerable<GroupDTO> TransformGroups(IEnumerable<Group> entities)
        {
            List<GroupDTO> entitiesDTO = new List<GroupDTO>();
            foreach (Group entity in entities)
                entitiesDTO.Add(TransformGroup(entity));
            return entitiesDTO;
        }
        public static AbsenceDTO TransformAbsence(Absence entity)
        {
            AbsenceDTO entityDTO = new AbsenceDTO();
            entityDTO.Id = entity.Id;
            entityDTO.StudentFirstname = entity.Student?.Firstname;
            entityDTO.StudentSecondname = entity.Student?.Secondname;
            entityDTO.SubjectName = entity.Subject?.SubjectName;
            entityDTO.Date = entity.Date;
            entityDTO.IsClosed = entity.IsClosed;
            return entityDTO;
        }
        public static IEnumerable<AbsenceDTO> TransformAbsences(IEnumerable<Absence> entities)
        {
            List<AbsenceDTO> entitiesDTO = new List<AbsenceDTO>();
            foreach (Absence entity in entities)
                entitiesDTO.Add(TransformAbsence(entity));
            return entitiesDTO;
        }
        public static TimetableDTO TransformTimetable(Timetable entity)
        {
            TimetableDTO entityDTO = new TimetableDTO();
            entityDTO.Id = entity.Id;
            entityDTO.Schedule = entity.Schedule;
            entityDTO.Changes = entity.Changes;
            return entityDTO;
        }
        public static IEnumerable<TimetableDTO> TransformTimetables(IEnumerable<Timetable> entities)
        {
            List<TimetableDTO> entitiesDTO = new List<TimetableDTO>();
            foreach (Timetable entity in entities)
                entitiesDTO.Add(TransformTimetable(entity));
            return entitiesDTO;
        }
        public static SubjectDTO TransformSubject(Subject entity)
        {
            SubjectDTO entityDTO = new SubjectDTO();
            entityDTO.Id = entity.Id;
            entityDTO.SubjectName = entity.SubjectName;
            entityDTO.Teacher = entity.Teacher;
            entityDTO.Hours = entity.Hours;
            return entityDTO;
        }
        public static IEnumerable<SubjectDTO> TransformSubjects(IEnumerable<Subject> entities)
        {
            List<SubjectDTO> entitiesDTO = new List<SubjectDTO>();
            foreach (Subject entity in entities)
                entitiesDTO.Add(TransformSubject(entity));
            return entitiesDTO;
        }
        public static StudentDTO TransformStudent(Student entity)
        {
            StudentDTO entityDTO = new StudentDTO();
            entityDTO.Id = entity.Id;
            entityDTO.GroupName = entity.Group?.GroupName;
            entityDTO.Firstname = entity.Firstname;
            entityDTO.Secondname = entity.Secondname;
            return entityDTO;
        }
        public static IEnumerable<StudentDTO> TransformStudents(IEnumerable<Student> entities)
        {
            List<StudentDTO> entitiesDTO = new List<StudentDTO>();
            foreach (Student entity in entities)
                entitiesDTO.Add(TransformStudent(entity));
            return entitiesDTO;
        }
        public static GradeDTO TransformGrade(Grade entity)
        {
            GradeDTO entityDTO = new GradeDTO();
            entityDTO.Id = entity.Id;
            entityDTO.StudentFirstname = entity.Student?.Firstname;
            entityDTO.StudentSecondname = entity.Student?.Secondname;
            entityDTO.SubjectName = entity.Subject?.SubjectName;
            entityDTO.Date = entity.Date;
            entityDTO.Value = entity.Value;
            return entityDTO;
        }
        public static IEnumerable<GradeDTO> TransformGrades(IEnumerable<Grade> entities)
        {
            List<GradeDTO> entitiesDTO = new List<GradeDTO>();
            foreach (Grade entity in entities)
                entitiesDTO.Add(TransformGrade(entity));
            return entitiesDTO;
        }
    }
}
