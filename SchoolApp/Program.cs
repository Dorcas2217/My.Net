// See https://aka.ms/new-console-template for more information
using Repository;
using SchoolApp.Models;
using SchoolApp.UnitOfWork;

IUnitOfWorkSchool unitOfWork = new UnitOfWorkSchool(new SchoolContext());
//IUnitOfWorkSchool unitOfWork = new UnitOfWorkSchool(new SchoolContext());
//IRepository<Section> repositorySection = new BaseRepositorySQL<Section>(new SchoolContext());
//IRepository<Student> repositoryStudent = new BaseRepositorySQL<Student>(new SchoolContext());


Section section1 = new Section();
section1.Name = "sectinfo";

Section section2 = new Section();
section2.Name = "sectdiet";

unitOfWork.SectionRepository.Save(section1, s => s.Name.Equals(section1.Name));
unitOfWork.SectionRepository.Save(section2, s => s.Name.Equals(section2.Name));

var sectionsList = unitOfWork.SectionRepository.GetAll();
foreach (var section in sectionsList)
{
    Console.WriteLine(section.Name);
}


Student student1 = new Student();
student1.Name = "studinfo1";
student1.Firstname = "student1";
student1.SectionId = section1.SectionId;
student1.YearResult = 100;

Student student2 = new Student();
student2.Name = "studdiet";
student2.Firstname = "student2";
student2.SectionId = section2.SectionId;
student2.YearResult = 120;

Student student3 = new Student();
student3.Name = "studinfo2";
student3.Firstname = "student3";
student3.SectionId = section1.SectionId;
student3.YearResult = 110;

unitOfWork.StudentRepository.Save(student1, s => ( s.Name.Equals(student1.Name) && s.Firstname.Equals(student1.Firstname)));
unitOfWork.StudentRepository.Save(student2, s => (s.Name.Equals(student2.Name) && s.Firstname.Equals(student2.Firstname)));
unitOfWork.StudentRepository.Save(student3, s => (s.Name.Equals(student3.Name) && s.Firstname.Equals(student3.Firstname)));

var studentList = unitOfWork.StudentRepository.GetAll();
foreach (var student in studentList)
{
    Console.WriteLine(student.Name);
}



