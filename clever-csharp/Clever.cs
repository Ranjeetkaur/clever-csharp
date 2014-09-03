using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using clever_csharp.model;

namespace clever_csharp
{
    public class Clever : IClever
    {
        private readonly CleverHttpClient _httpClient;
        
        public Clever(string accessToken)
        {
            _httpClient = new CleverHttpClient(new AuthenticationHeaderValue("Bearer", accessToken));
        }

        #region District Queries

        public Districts GetDistricts(IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Districts);
            return _httpClient.Get<Districts>(queryUri);
        }

        public DistrictResp GetDistrictById(string districtId, ApiParam includeEndPoints = null)
        {
            var queryUri = UrlUtils.UriMaker(includeEndPoints == null ? null : new List<ApiParam> { includeEndPoints }, UrlUtils.Districts, districtId);
            return _httpClient.Get<DistrictResp>(queryUri);
        }

        public Teachers GetDistrictTeachers(string districtId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Districts, districtId, UrlUtils.Teachers);
            return _httpClient.Get<Teachers>(queryUri);
        }

        public Schools GetDistrictSchools(string districtId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Districts, districtId, UrlUtils.Schools);
            return _httpClient.Get<Schools>(queryUri);
        }

        public Students GetDistrictStudents(string districtId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Districts, districtId, UrlUtils.Students);
            return _httpClient.Get<Students>(queryUri);
        }

        #endregion District Queries

        #region School Queries

        public Schools GetSchools(IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Schools);
            return _httpClient.Get<Schools>(queryUri);
        }

        // Known Issue: Error when adding district to the includeEndPoints param
        // the returned json uses the 'district' property to return a string:id when district not passed to the api
        // and when district passed to the api, 'district' property is a complex type district(id,name):district
        public SchoolResp GetSchoolById(string schoolId, ApiParam includeEndPoints = null)
        {
            var queryUri = UrlUtils.UriMaker(includeEndPoints == null ? null : new List<ApiParam> { includeEndPoints }, UrlUtils.Schools, schoolId);
            return _httpClient.Get<SchoolResp>(queryUri);
        }

        public Teachers GetSchoolTeachers(string schoolId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Schools, schoolId, UrlUtils.Teachers);
            return _httpClient.Get<Teachers>(queryUri);
        }

        public Students GetSchoolStudents(string schoolId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Schools, schoolId, UrlUtils.Students);
            return _httpClient.Get<Students>(queryUri);
        }

        public DistrictResp GetSchoolDistrict(string schoolId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Schools, schoolId, UrlUtils.District);
            return _httpClient.Get<DistrictResp>(queryUri);
        }

        #endregion School Queries

        #region Teacher Queries

        public Teachers GetTeachers(IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Teachers);
            return _httpClient.Get<Teachers>(queryUri);
        }

        // Known Issue: Error when adding district or school to the includeEndPoints param
        // the returned json uses the 'district'|'school' property to return a string:id when district|school not passed to the api
        // and when district|school passed to the api, 'district'|'school' property is a complex type e.g. district:district(id,name)
        public TeacherResp GetTeacherById(string teacherId, ApiParam includeEndPoints = null)
        {
            var queryUri = UrlUtils.UriMaker(includeEndPoints == null ? null : new List<ApiParam> { includeEndPoints }, UrlUtils.Teachers, teacherId);
            return _httpClient.Get<TeacherResp>(queryUri);
        }

        public SchoolResp GetTeacherSchool(string teacherId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Teachers, teacherId, UrlUtils.Schools);
            return _httpClient.Get<SchoolResp>(queryUri);
        }

        public DistrictResp GetTeacherDistrict(string teacherId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Teachers, teacherId, UrlUtils.District);
            return _httpClient.Get<DistrictResp>(queryUri);
        }

        public Students GetTeacherStudents(string teacherId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Teachers, teacherId, UrlUtils.Students);
            return _httpClient.Get<Students>(queryUri);
        }

        #endregion Teacher Queries

        #region Student Queries

        public Students GetStudents(IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Students);
            return _httpClient.Get<Students>(queryUri);
        }

        public StudentResp GetStudentById(string studentId, ApiParam includeEndPoints = null)
        {
            var queryUri = UrlUtils.UriMaker(includeEndPoints == null ? null : new List<ApiParam> { includeEndPoints }, UrlUtils.Students, studentId);
            return _httpClient.Get<StudentResp>(queryUri);
        }

        public SchoolResp GetStudentsSchool(string studentId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Students, studentId, UrlUtils.Schools);
            return _httpClient.Get<SchoolResp>(queryUri);
        }

        public DistrictResp GetStudentDistrict(string studentId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Students, studentId, UrlUtils.District);
            return _httpClient.Get<DistrictResp>(queryUri);
        }

        public Teachers GetStudentTeachers(string studentId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Students, studentId, UrlUtils.District);
            return _httpClient.Get<Teachers>(queryUri);
        }

        #endregion Studen Queries

        #region User Queries /me

        public UserResponse GetUser()
        {
            var queryUri = new Uri(UrlUtils.MeApiUrl);
            return _httpClient.Get<UserResponse>(queryUri);
        }

        #endregion User Queries /me
    }
}
