using clever_csharp;
using clever_csharp.model;
using NUnit.Framework;

namespace clever.tests
{
    [TestFixture]
    public class DistrictIntegrationTests : BaseIntegrationTests
    {
        [Test]
        public void query_get_districts()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetDistricts();
            Assert.That(results,Is.Not.Null);
            Assert.That(results.data.Count, Is.EqualTo(1));
        }

        [Test]
        public void query_get_district_by_id()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetDistrictById(DistrictId);
            Assert.That(results, Is.Not.Null);
        }

        [Test]
        public void query_get_district_by_id_include_schools()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetDistrictById(DistrictId, new ApiParam("include","schools"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.data.schools, Is.Not.Null);
            Assert.That(results.data.schools.data.Count, Is.EqualTo(3));
        }

        [Test]
        public void query_get_district_by_id_include_schools_teachers_students()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetDistrictById(DistrictId, new ApiParam("include", "schools,teachers,students"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.data.schools, Is.Not.Null);
            Assert.That(results.data.schools.data.Count, Is.EqualTo(3));
            Assert.That(results.data.teachers, Is.Not.Null);
            Assert.That(results.data.students, Is.Not.Null);
        }

        [Test]
        public void query_get_district_teachers()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetDistrictTeachers(DistrictId);
            Assert.That(results, Is.Not.Null);
        }

        [Test]
        public void query_get_district_schools()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetDistrictTeachers(DistrictId);
            Assert.That(results, Is.Not.Null);
        }

        [Test]
        public void query_get_district_studetns()
        {
            var clever = new Clever(DemoToken);
            var results = clever.GetDistrictTeachers(DistrictId);
            Assert.That(results, Is.Not.Null);
        }
    }
}
