using clever_csharp;
using clever_csharp.model;
using NUnit.Framework;

namespace clever.tests
{
    [TestFixture]
    public class TeacherIntegrationTests : BaseIntegrationTests
    {
        [Test]
        public void query_get_Teachers()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetTeachers();
            Assert.That(results, Is.Not.Null);
        }

        [Test]
        public void query_get_Teacher_by_id()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetTeacherById(TeacherId);
            Assert.That(results, Is.Not.Null);
        }

        // known issue with include=district
        [Test, Ignore]
        public void query_get_Teacher_by_id_include_district()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetTeacherById(TeacherId, new ApiParam("include", "district"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.data.district, Is.Not.Null);
        }

        [Test]
        public void query_get_Teacher_by_id_include_students()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetTeacherById(TeacherId, new ApiParam("include", "students"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.data.students, Is.Not.Null);
        }

        // known issue, school property can be complex type of string id. meh!
        [Test, Ignore]
        public void query_get_Teacher_by_id_include_school()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetTeacherById(TeacherId, new ApiParam("include", "school"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.data.school, Is.Not.Null);
        }

        //[Test]
        //public void query_get_Teacher_by_id_include_DemoToken_students()
        //{
        //    var clever = new Clever(DemoToken);
        //    var results = clever.GetTeacherById(TeacherId, new ApiParam("include", "DemoToken,students"));
        //    Assert.That(results, Is.Not.Null);
        //    Assert.That(results.data.DemoToken, Is.Not.Null);
        //    Assert.That(results.data.students, Is.Not.Null);
        //}

        //[Test]
        //public void query_get_Teacher_by_id_include_DemoToken_students_district()
        //{
        //    var clever = new Clever(DemoToken);
        //    var results = clever.GetTeacherByIdWithDistrict(TeacherId, new ApiParam("include", "DemoToken,students,district"));
        //    Assert.That(results, Is.Not.Null);
        //    Assert.That(results.data.DemoToken, Is.Not.Null);
        //    Assert.That(results.data.students, Is.Not.Null);
        //    Assert.That(results.data.district, Is.Not.Null);
        //}

        //[Test]
        //public void query_get_Teacher_DemoToken()
        //{
        //    var clever = new Clever(DemoToken);
        //    var results = clever.GetTeacherDemoToken(TeacherId);
        //    Assert.That(results, Is.Not.Null);
        //}

        //[Test]
        //public void query_get_Teacher_students()
        //{
        //    var clever = new Clever(DemoToken);
        //    var results = clever.GetTeacherstudents(TeacherId);
        //    Assert.That(results, Is.Not.Null);
        //}
    }
}
