using System.Data.SqlClient;

namespace Cw4.Services;

public class AnimalService
{
    public void AddAnimal(Animal animal)
    {
        using (var con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20373;Integrated Security=True"))
        {
            var com = new SqlCommand(
                $"INSERT INTO Animals (Name, Description, Category, Area)" +
                $"VALUES (@param2, @param3, @param4, @param5)", con);
            // com.Parameters.AddWithValue("@param1", animal.IdAnimal);
            com.Parameters.AddWithValue("@param2", animal.Name);
            com.Parameters.AddWithValue("@param3", animal.Description);
            com.Parameters.AddWithValue("@param4", animal.Category);
            com.Parameters.AddWithValue("@param5", animal.Area);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy, string sort)
    {
        var res = new List<Animal>();
        //System.Data.SqlClient
        using (var con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20373;Integrated Security=True"))
        {
            var com = new SqlCommand($"SELECT * FROM Animals ORDER BY {orderBy} {sort}", con);
            con.Open();
            var dr = com.ExecuteReader();
            while (dr.Read())
            {
                res.Add(new Animal
                {
                    IdAnimal = int.Parse(dr["IdAnimal"].ToString()),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString(),
                }); ;
            }
        }
        return res;
    }

    public void UpdateAnimal(int idAnimal, Animal animal)
    {
        using (var con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20373;Integrated Security=True"))
        {
            var com = new SqlCommand(
                $"UPDATE Animals SET name = @param2, description = @param3, category = @param4, area = @param5 WHERE IdAnimal = @param1",
                con
            );

            com.Parameters.AddWithValue("@param1", idAnimal);
            com.Parameters.AddWithValue("@param2", animal.Name);
            com.Parameters.AddWithValue("@param3", animal.Description);
            com.Parameters.AddWithValue("@param4", animal.Category);
            com.Parameters.AddWithValue("@param5", animal.Area);
            
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }

    public void DeleteAnimal(int idAnimal)
    {
        using (var con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20373;Integrated Security=True"))
        {
            var com = new SqlCommand(
                $"DELETE FROM Animals WHERE IdAnimal = @param1",
                con
            );

            com.Parameters.AddWithValue("@param1", idAnimal);
            
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}