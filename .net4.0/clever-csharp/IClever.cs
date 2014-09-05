using System.Collections.Generic;
using clever_csharp.model;

namespace clever_csharp
{
    public interface IClever
    {
        /// <summary>
        /// GET /v1.1/districts
        /// Gets a list of districts you have access to across all districts
        /// </summary>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// <returns>Districts</returns>
        Districts GetDistricts(IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET /v1.1/districts/{id}
        /// Get only a specific district's information
        /// </summary>
        /// <param name="districtId">District id</param>
        /// <param name="includeEndPoints">comma-separated list of second-level value endpoints to include in the response</param>
        /// <returns>DistrictResp</returns>
        DistrictResp GetDistrictById(string districtId, ApiParam includeEndPoints = null);

        /// <summary>
        /// GET /v1.1/districts/{id}/teachers
        /// Retrieves a list of teachers you have access to for a specific district
        /// </summary>
        /// <param name="districtId">District Id</param>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// <returns>Teachers</returns>
        Teachers GetDistrictTeachers(string districtId, IEnumerable<ApiParam> queryParams = null);


        /// <summary>
        /// GET /v1.1/districts/{id}/schools
        /// Retrieves a list of schools you have access to for a specific district
        /// </summary>
        /// <param name="districtId">Distric Id</param>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// <returns>Schools</returns>
        Schools GetDistrictSchools(string districtId, IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET /v1.1/districts/{id}/students
        /// Retrieves a list of students you have access to for a specific district
        /// </summary>
        /// <param name="districtId">District Id</param>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// <returns>Students</returns>
        Students GetDistrictStudents(string districtId, IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET /v1.1/schools
        /// Gets a list of schools you have access to across all districts
        /// </summary>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// <returns></returns>
        Schools GetSchools(IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET/v1.1/schools/{id}
        /// GET/v1.1/schools/{id}?include=teachers,students
        /// Get only a specific schools's information
        /// </summary>
        /// <param name="schoolId">schools id</param>
        /// <param name="includeEndPoints">optional: comma-separated list of second-level endpoints to include in the response</param>
        /// <returns>District</returns>
        SchoolResp GetSchoolById(string schoolId, ApiParam includeEndPoints = null);

        /// <summary>
        /// GET /v1.1/schools/{id}/teachers
        /// Retrieves a list of all teachers for a specific school
        /// </summary>
        /// <param name="schoolId">School id</param>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// <returns>Teachers</returns>
        Teachers GetSchoolTeachers(string schoolId, IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET /v1.1/schools/{id}/students
        /// Retrieves a list of students you have access to for a specific school
        /// </summary>
        /// <param name="schoolId">School Id</param>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// <returns>Students</returns>
        Students GetSchoolStudents(string schoolId, IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET /v1.1/schools/{id}/district
        /// Retrieves district information for a school
        /// <param name="schoolId">School Id</param>
        /// </summary>
        /// <returns>DistrictResp</returns>
        DistrictResp GetSchoolDistrict(string schoolId);

        /// <summary>
        /// GET /v1.1/teachers
        /// Gets a list of teachers you have access to across all districts
        /// </summary>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// <returns>Teachers</returns>
        Teachers GetTeachers(IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET/v1.1/teachers/{id}
        /// GET/v1.1/teachers/{id}?include=district
        /// Get only a specific teachers's information
        /// </summary>
        /// <param name="teacherId">teacher id</param>
        /// <param name="includeEndPoints">comma-separated list of second-level endpoints to include in the response</param>
        /// <returns>TeacherResp</returns>
        TeacherResp GetTeacherById(string teacherId, ApiParam includeEndPoints = null);

        /// <summary>
        /// GET /v1.1/teachers/{id}/school
        /// Retrieves information about the school for a teacher
        /// </summary>
        /// <param name="teacherId">teacher id</param>
        /// <returns>SchoolResp</returns>
        SchoolResp GetTeacherSchool(string teacherId);

        /// <summary>
        /// GET /v1.1/teachers/{id}/district
        /// Retrieves district information for a teacher
        /// </summary>
        /// <param name="teacherId">teacher id</param>
        /// <returns>DistrictResp</returns>
        DistrictResp GetTeacherDistrict(string teacherId);

        /// <summary>
        /// GET /v1.1/teachers/{id}/students
        /// Retrieves all students that a teacher has in their sections
        /// <param name="teacherId">teacher Id</param>
        /// /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// </summary>
        /// <returns>Students</returns>
        Students GetTeacherStudents(string teacherId, IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET /v1.1/students
        /// Gets a list of students you have access to across all districts
        /// </summary>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// <returns>Students</returns>
        Students GetStudents(IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET/v1.1/students/{id}
        /// GET/v1.1/students/{id}?include=district
        /// Get only a specific students's information
        /// </summary>
        /// <param name="studentId">students id</param>
        /// <param name="includeEndPoints">comma-separated list of second-level endpoints to include in the response</param>
        /// <returns>StudentResp</returns>
        StudentResp GetStudentById(string studentId, ApiParam includeEndPoints = null);

        /// <summary>
        /// GET /v1.1/students/{id}/school
        /// Retrieves information about the school for a student
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>SchoolResp</returns>
        SchoolResp GetStudentsSchool(string studentId);

        /// <summary>
        /// GET /v1.1/students/{id}/district
        /// Retrieves district information for a student
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>DistrictResp</returns>
        DistrictResp GetStudentDistrict(string studentId);

        /// <summary>
        /// GET /v1.1/students/{id}/teachers
        /// Retrieves all teachers for a student
        /// <param name="studentId">student Id</param>
        /// <param name="queryParams">list of api query parameters see https://clever.com/developers/docs/explorer#api_data for details</param>
        /// </summary>
        /// <returns>Students</returns>
        Teachers GetStudentTeachers(string studentId, IEnumerable<ApiParam> queryParams = null);

        /// <summary>
        /// GET /me
        /// Once you've received an access token, you can look up the user associated with the token
        /// </summary>
        /// <returns>UserResponse</returns>
        UserResponse GetUser();

    }
}