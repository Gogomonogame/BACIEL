using College.Domain.Repositories.Abstract;

namespace College.Domain
{
    public class DataManager
    {
        public IGroupRepository Groups { get; set; }
        public IStudentRepository Students { get; set; }
        public IGradeRepository Grades { get; set; }
        public IAbsenceRepository Absences { get; set; }
        public ISubjectRepository Subjects { get; set; }
        public ITimetableRepository Timetables { get; set; }

        public DataManager(IGroupRepository groups, IStudentRepository students, IGradeRepository grades, IAbsenceRepository absences, ISubjectRepository subjects, ITimetableRepository timetables)
        {
            Groups = groups;
            Students = students;
            Grades = grades;
            Absences = absences;
            Subjects = subjects;
            Timetables = timetables;
        }
    }
}
