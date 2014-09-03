using System;
using System.Collections.Generic;

namespace clever_csharp.model
{
    public class School
    {
        public DateTime created { get; set; }
        public string district { get; set; }
        public string high_grade { get; set; }
        public DateTime last_modified { get; set; }
        public Location location { get; set; }
        public string low_grade { get; set; }
        public string name { get; set; }
        public string nces_id { get; set; }
        public string phone { get; set; }
        public Principal principal { get; set; }
        public string school_number { get; set; }
        public string sis_id { get; set; }
        public string state_id { get; set; }
        public string id { get; set; }
        public Teachers teachers { get; set; }
        public Students students { get; set; }
        public District district_resp { get; set; }
    }

    // have to do this: adding the include segment "district" returns the a district Obj without it returns string district id.
    public class SchoolWithDistrict : School
    {
        public DistrictResp district { get; set; }
    }

    public class SchoolWithDistrictResp
    {
        public SchoolWithDistrict data { get; set; }
        public IList<Links> links { get; set; }
    }

    public class SchoolResp
    {
        public School data { get; set; }
        public IList<Links> links { get; set; }
    }

    public class Schools
    {
        public IList<SchoolResp> data { get; set; }
        public Paging paging { get; set; }
        public IList<Links> links { get; set; }
    }

    public class Teacher
    {
        public DateTime created { get; set; }
        public Credentials credentials { get; set; }
        public string district { get; set; }
        public string email { get; set; }
        public DateTime last_modified { get; set; }
        public Name name { get; set; }
        public string school { get; set; }
        public string sis_id { get; set; }
        public string teacher_number { get; set; }
        public string title { get; set; }
        public string id { get; set; }
        public Students students { get; set; }
        //public School school { get; set; }
    }

    public class TeacherWithDistrict : Teacher
    {
        public DistrictResp district { get; set; }
    }

    public class TeacherWithDistrictResp
    {
        public TeacherWithDistrict data { get; set; }
        public IList<Links> links { get; set; }
    }

    public class TeacherResp
    {
        public Teacher data { get; set; }
        public string uri { get; set; }
    }

    public class Teachers
    {
        public IList<TeacherResp> data { get; set; }
        public Paging paging { get; set; }
        public IList<Links> links { get; set; }
    }

    public class Student
    {
        public DateTime created { get; set; }
        public Credentials credentials { get; set; }
        public string district { get; set; }
        public string dob { get; set; }
        public string ell_status { get; set; }
        public string email { get; set; }
        public string frl_status { get; set; }
        public string gender { get; set; }
        public string grade { get; set; }
        public string hispanic_ethnicity { get; set; }
        public string iep_status { get; set; }
        public DateTime last_modified { get; set; }
        public Location location { get; set; }
        public Name name { get; set; }
        public string race { get; set; }
        public string school { get; set; }
        public string sis_id { get; set; }
        public string state_id { get; set; }
        public string student_number { get; set; }
        public string id { get; set; }
    }

    public class StudentResp
    {
        public Student data { get; set; }
        public IList<Links> links { get; set; }
    }

    public class Students
    {
        public IList<StudentResp> data { get; set; }
        public Paging paging { get; set; }
        public IList<Links> links { get; set; }
    }

    public class District
    {
        public string name { get; set; }
        public string id { get; set; }
        public Schools schools { get; set; }
        public Teachers teachers { get; set; }
        public Students students { get; set; }
    }

    public class DistrictResp
    {
        public District data { get; set; }
        public IList<Links> links { get; set; }
    }

    public class Districts
    {
        public IList<DistrictResp> data { get; set; }
        public Paging paging { get; set; }
        public IList<Links> links { get; set; }
    }

    public class Links
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

    public class Credentials
    {
        public string district_username { get; set; }
        public string district_password { get; set; }
    }

    public class Location
    {
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }

    public class Name
    {
        public string first { get; set; }
        public string middle { get; set; }
        public string last { get; set; }
    }

    public class Principal
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Paging
    {
        public int current { get; set; }
        public int total { get; set; }
        public int count { get; set; }
    }

    public class TokenRequest
    {
        public string code { get; set; }
        public string grant_type { get; set; }
        public string redirect_uri { get; set; }
    }

    public class AccessTokenResponse
    {
        public string access_token { get; set; }
    }

    public class UserResponse
    {
        public User data { get; set; }
    }

    public class User
    {
        public string district { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }
}
