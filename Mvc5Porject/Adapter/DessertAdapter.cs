using Mvc5Porject.Adapter.ConnStr;
using Mvc5Porject.Adapter.InterFace;
using Mvc5Porject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;

namespace Mvc5Porject.Adapter
{
    public class DessertAdapter : DataBase, IDessertAdapter
    {
        public bool Create(Dessert dessert)
        {
            using(conn = new SqlConnection(ConnStr))
            {
                string sql = @"Insert Dessert (DessertID,DessertName,DessertPrice,DessertKind,DessertIntroduction,DessertImage,IsOnSale)
                                values (@DessertID,@DessertName,@DessertPrice,@DessertKind,@DessertIntroduction,@DessertImage,1)";
                if (conn.Execute(sql, dessert) > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool Delete(string dessertID)
        {
            using(conn = new SqlConnection(ConnStr))
            {
                string sql = @"Delete Dessert where DessertID = @DessertID";
                if (conn.Execute(sql, new { DessertID = dessertID }) > 0)
                    return true;
                else
                    return false;
            }
        }

        public Dessert Get(string dessertID)
        {
            using(conn = new SqlConnection(ConnStr))
            {
                string sql = @"select * from Dessert where DessertID = @DessertID";
                return conn.QueryFirstOrDefault<Dessert>(sql, new { DessertID = dessertID });
            }
        }

        public List<Dessert> GetList()
        {
            using(conn = new SqlConnection(ConnStr))
            {
                string sql = @"select * from Dessert";
                return conn.Query<Dessert>(sql).ToList();
            }
        }

        public bool Update(Dessert dessert)
        {
            using(conn = new SqlConnection(ConnStr))
            {
                string sql = @"Update Dessert set DessertName = @DessertName ,DessertPrice = @DessertPrice, DessertKind = @DessertKind,
                    DessertIntroduction = @DessertIntroduction,DessertImage = @DessertImage , IsOnSale = @IsOnSale where DessertID = @DessertID";
                if (conn.Execute(sql, dessert) > 0)
                    return true;
                else
                    return false;
            }
            
        }
    }
}