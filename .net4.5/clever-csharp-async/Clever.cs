using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using clever_csharp_async.model;

namespace clever_csharp_async
{
    public class Clever : IClever
    {
        private readonly CleverHttpClient _httpClient;

        public Clever(string accessToken)
        {
             _httpClient = new CleverHttpClient(new AuthenticationHeaderValue("Bearer", accessToken));
        }

        #region District Queries

        public async Task<Districts> GetDistrictsAsync(IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Districts);
            return await _httpClient.Get<Districts>(queryUri);
        }

        public async Task<DistrictResp> GetDistrictByIdAsync(string districtId, ApiParam includeEndPoints = null)
        {
            var queryUri = UrlUtils.UriMaker(includeEndPoints == null ? null : new List<ApiParam> { includeEndPoints }, UrlUtils.Districts, districtId);
            return await _httpClient.Get<DistrictResp>(queryUri);
        }

        public async Task<Teachers> GetDistrictTeachersAsync(string districtId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Districts, districtId, UrlUtils.Teachers);
            return await _httpClient.Get<Teachers>(queryUri);
        }

        public async Task<Schools> GetDistrictSchoolsAsync(string districtId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Districts, districtId, UrlUtils.Schools);
            return await _httpClient.Get<Schools>(queryUri);
        }

        public async Task<Students> GetDistrictStudentsAsync(string districtId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Districts, districtId, UrlUtils.Students);
            return await _httpClient.Get<Students>(queryUri);
        }

        #endregion District Queries

        #region School Queries

        public async Task<Schools> GetSchoolsAsync(IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Schools);
            return await _httpClient.Get<Schools>(queryUri);
        }

        // Known Issue: Error when adding district to the includeEndPoints param
        // the returned json uses the 'district' property to return a string:id when district not passed to the api
        // and when district passed to the api, 'district' property is a complex type district(id,name):district
        public async Task<SchoolResp> GetSchoolByIdAsync(string schoolId, ApiParam includeEndPoints = null)
        {
            var queryUri = UrlUtils.UriMaker(includeEndPoints == null ? null : new List<ApiParam> { includeEndPoints }, UrlUtils.Schools, schoolId);
            return await _httpClient.Get<SchoolResp>(queryUri);
        }

        public async Task<Teachers> GetSchoolTeachersAsync(string schoolId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Schools, schoolId, UrlUtils.Teachers);
            return await _httpClient.Get<Teachers>(queryUri);
        }

        public async Task<Students> GetSchoolStudentsAsync(string schoolId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Schools, schoolId, UrlUtils.Students);
            return await _httpClient.Get<Students>(queryUri);
        }

        public async Task<DistrictResp> GetSchoolDistrictAsync(string schoolId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Schools, schoolId, UrlUtils.District);
            return await _httpClient.Get<DistrictResp>(queryUri);
        }

        #endregion School Queries

        #region Teacher Queries

        public async Task<Teachers> GetTeachersAsync(IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Teachers);
            return await _httpClient.Get<Teachers>(queryUri);
        }

        // Known Issue: Error when adding district or school to the includeEndPoints param
        // the returned json uses the 'district'|'school' property to return a string:id when district|school not passed to the api
        // and when district|school passed to the api, 'district'|'school' property is a complex type e.g. district:district(id,name)
        public async Task<TeacherResp> GetTeacherByIdAsync(string teacherId, ApiParam includeEndPoints = null)
        {
            var queryUri = UrlUtils.UriMaker(includeEndPoints == null ? null : new List<ApiParam> { includeEndPoints }, UrlUtils.Teachers, teacherId);
            return await _httpClient.Get<TeacherResp>(queryUri);
        }

        public async Task<SchoolResp> GetTeacherSchoolAsync(string teacherId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Teachers, teacherId, UrlUtils.Schools);
            return await _httpClient.Get<SchoolResp>(queryUri);
        }

        public async Task<DistrictResp> GetTeacherDistrictAsync(string teacherId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Teachers, teacherId, UrlUtils.District);
            return await _httpClient.Get<DistrictResp>(queryUri);
        }

        public async Task<Students> GetTeacherStudentsAsync(string teacherId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Teachers, teacherId, UrlUtils.Students);
            return await _httpClient.Get<Students>(queryUri);
        }

        #endregion Teacher Queries

        #region Student Queries

        public async Task<Students> GetStudentsAsync(IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(queryParams, UrlUtils.Students);
            return await _httpClient.Get<Students>(queryUri);
        }

        public async Task<StudentResp> GetStudentByIdAsync(string studentId, ApiParam includeEndPoints = null)
        {
            var queryUri = UrlUtils.UriMaker(includeEndPoints == null ? null : new List<ApiParam> { includeEndPoints }, UrlUtils.Students, studentId);
            return await _httpClient.Get<StudentResp>(queryUri);
        }

        public async Task<SchoolResp> GetStudentsSchoolAsync(string studentId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Students, studentId, UrlUtils.Schools);
            return await _httpClient.Get<SchoolResp>(queryUri);
        }

        public async Task<DistrictResp> GetStudentDistrictAsync(string studentId)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Students, studentId, UrlUtils.District);
            return await _httpClient.Get<DistrictResp>(queryUri);
        }

        public async Task<Teachers> GetStudentTeachersAsync(string studentId, IEnumerable<ApiParam> queryParams = null)
        {
            var queryUri = UrlUtils.UriMaker(null, UrlUtils.Students, studentId, UrlUtils.District);
            return await _httpClient.Get<Teachers>(queryUri);
        }

        #endregion Studen Queries

        #region User Queries /me

        public async Task<UserResponse> GetUserAsync()
        {
            var queryUri = new Uri(UrlUtils.MeApiUrl);
            return await _httpClient.Get<UserResponse>(queryUri);
        }

        #endregion User Queries /me
    }
}
