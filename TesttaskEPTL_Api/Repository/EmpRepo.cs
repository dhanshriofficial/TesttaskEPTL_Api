using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesttaskEPTL_Api.MasterInterface;
using TesttaskEPTL_Api.Models;
using Microsoft.Data.SqlClient;
using TesttaskEPTL_Api.Data_Context;
using System.Data;

namespace TesttaskEPTL_Api.Repository
{
    public class EmpRepo : IEmployee
    {

        Connection con;
        SqlConnection sqlcon;
        SqlCommand sqlcmd;
        public int saveorupdate(EmployeeModel model)
        {
            int _response;
            int flag;
            con = new Connection();
            sqlcon = new SqlConnection();
            sqlcmd = new SqlCommand();
            sqlcon = con.Connect();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_postdata".Trim();
            sqlcmd.Parameters.AddWithValue("@Emp_id", model.Id);
            sqlcmd.Parameters.AddWithValue("@Emp_Name", model.Emp_name);
            sqlcmd.Parameters.AddWithValue("@Emp_Address", model.Emp_address);
            sqlcmd.Parameters.AddWithValue("@Emp_Contact", model.Emp_contact);
            sqlcmd.Parameters.AddWithValue("@Emp_DOB", model.Emp_DOB);
            sqlcmd.Parameters.AddWithValue("@Emp_Designation", model.Emp_designation);
            sqlcmd.Parameters.AddWithValue("@Emp_Email", model.Emp_email);
            sqlcmd.Parameters.AddWithValue("@Emp_Salary", model.Emp_salary);
            if (model.Id == 0)
            {
                flag = 1;
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                _response = 0;
            }
            else
            {
                flag = 2;
                sqlcmd.Parameters.AddWithValue("@flag", flag);
                _response = 1;
            }
            sqlcmd.ExecuteNonQuery();
            return _response;
        
        }
        public List<EmployeeModel> Getdata()
        {
            int i;
            List<EmployeeModel> _list = new List<EmployeeModel>();
            DataTable dt = new DataTable();
            con = new Connection();
            dt = con.FetchQuery("select Emp_id,Emp_Name,[Emp_Address],Emp_Contact,Emp_DOB,Emp_Designation,Emp_Email,Emp_Salary from Employeetable");
            for (i = 0; i < dt.Rows.Count; i++)
            {
                EmployeeModel _model = new EmployeeModel();
                _model.Id = Convert.ToInt32(dt.Rows[i]["Emp_id"]);
                _model.Emp_name = dt.Rows[i]["Emp_name"].ToString();
                _model.Emp_address = dt.Rows[i]["Emp_address"].ToString();
                _model.Emp_contact = dt.Rows[i]["Emp_contact"].ToString();
                _model.Emp_DOB = Convert.ToDateTime(dt.Rows[i]["Emp_DOB"]);
                _model.Emp_designation = dt.Rows[i]["Emp_designation"].ToString();
                _model.Emp_email = dt.Rows[i]["Emp_email"].ToString();
                _model.Emp_salary = Convert.ToDecimal(dt.Rows[i]["Emp_salary"]);
                _list.Add(_model);
            }
            return _list;
        }
        public EmployeeModel Edit(int id, EmployeeModel model)
        {
            EmployeeModel _model = new EmployeeModel();
            sqlcon = new SqlConnection();
            sqlcmd = new SqlCommand();
            con = new Connection();
            sqlcon = con.Connect();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.Text;
            //DataTable dt = new DataTable();
          string  str = "select Emp_id,Emp_Name,Emp_Address,Emp_Contact,Emp_DOB,Emp_Designation,Emp_Email,Emp_Salary from Employeetable where Emp_id=@id";
            sqlcmd.CommandText = str;
            sqlcmd.Parameters.AddWithValue("@id", id);
            
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                _model.Id = Convert.ToInt32(reader["Emp_id"]);
                _model.Emp_name = reader["Emp_name"].ToString()??"";
                _model.Emp_address = reader["Emp_address"].ToString() ?? "";
                _model.Emp_contact = reader["Emp_contact"].ToString() ?? "";
                _model.Emp_DOB = Convert.ToDateTime(reader["Emp_DOB"]);
                _model.Emp_designation = reader["Emp_designation"].ToString() ?? "";
                _model.Emp_email = reader["Emp_email"].ToString() ?? "";
                _model.Emp_salary = Convert.ToDecimal(reader["Emp_Salary"]);
               
            }
            reader.Close();
            sqlcon.Close();
            return _model;
        }

            
        public void Delete(int id)
        {
            DataTable dt = new DataTable();
            con = new Connection();
            sqlcon = new SqlConnection();
            sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            dt = con.FetchQuery("delete Employeetable where Emp_id=" + id);
           
        }

    }
}
