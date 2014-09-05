using clever_csharp;
using clever_csharp.model;
using NUnit.Framework;

namespace clever.tests
{
    [TestFixture]
    public class SchoolIntegrationTests : BaseIntegrationTests
    {
        [Test]
        public void query_get_schools()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetSchools();
            Assert.That(results, Is.Not.Null);
        }

        [Test]
        public void query_get_School_by_id()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetSchoolById(SchoolId);
            Assert.That(results, Is.Not.Null);
        }

        // known issue with include=district
        [Test, Ignore]
        public void query_get_School_by_id_include_district()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetSchoolById(SchoolId,new ApiParam("include","district"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.data.district, Is.Not.Null);
        }

        [Test]
        public void query_get_School_by_id_include_students()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetSchoolById(SchoolId, new ApiParam("include", "students"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.data.students, Is.Not.Null);
        }

        [Test]
        public void query_get_School_by_id_include_teachers_students()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetSchoolById(SchoolId, new ApiParam("include", "teachers,students"));
            Assert.That(results, Is.Not.Null); 
            Assert.That(results.data.teachers, Is.Not.Null);
            Assert.That(results.data.students, Is.Not.Null);
        }

        // known issue with include=district
        [Test, Ignore]
        public void query_get_School_by_id_include_teachers_students_district()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetSchoolById(SchoolId, new ApiParam("include", "teachers,students,district"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.data.teachers, Is.Not.Null);
            Assert.That(results.data.students, Is.Not.Null);
            Assert.That(results.data.district, Is.Not.Null);
        }

        [Test]
        public void query_get_School_teachers()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetSchoolTeachers(SchoolId);
            Assert.That(results, Is.Not.Null);
        }

        [Test]
        public void query_get_School_students()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetSchoolStudents(SchoolId);
            Assert.That(results, Is.Not.Null);
        }
    }
}
