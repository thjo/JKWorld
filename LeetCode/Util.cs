using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Util
    {
        //var results = csvList
        //    .Where(x => x.Grp == "DEFAULT")
        //    .OrderBy(x => x.Date)
        //    .Select(x => x.Grp);

        //var orderByResult = from s in studentList
        //                   orderby s.StudentName
        //                   select s;

        //var orderByDescendingResult = from s in studentList
        //                      orderby s.StudentName descending
        //                      select s;

        //var QS = (from std in Student.GetAllStudents()
        //          where std.Branch.ToUpper() == "CSE"
        //          orderby std.FirstName
        //          select std);

        //Var movies = _db.Movies.OrderBy(c => c.Category).ThenBy(n => n.Name)
        //i found two sample code which shows how to use multiple column name with order by
        //var movies = from row in _db.Movies
        //     orderby row.Category, row.Name
        //     select row;
        //OR
        //var movies = from row in _db.Movies
        //             orderby row.Category descending, row.Name
        //             select row;
        //var movies = _db.Movies.OrderBy(c => c.Category).ThenBy(n => n.Name)
        public static void Sort<T>(T[][] data, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        }
    }
}
