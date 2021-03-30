using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext context;

        public CourseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Course>> GetCourses()
        {
            if (context != null)
            {
                return await context.Courses.ToListAsync();
            }

            return null;
        }



        public async Task<Course> GetById(int Id)
        {
            if (context != null)
            {
                return await context.Courses.FirstOrDefaultAsync(s => s.Id == Id);
            }

            return null;
        }

        public async Task<int> Add(Course Course)
        {
            if (context != null)
            {
                await context.Courses.AddAsync(Course);
                await context.SaveChangesAsync();

                return Course.Id;
            }

            return 0;
        }

        public async Task<int> Delete(int Id)
        {
            int result = 0;

            if (context != null)
            {
                //Find for specific Course id
                var Course = await context.Courses.FirstOrDefaultAsync(s => s.Id == Id);

                if (Course != null)
                {
                    //Delete 
                    context.Courses.Remove(Course);

                    //Commit the transaction
                    result = await context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task Update(Course Course)
        {
            if (context != null)
            {
                context.Courses.Update(Course);
                await context.SaveChangesAsync();
            }
        }
    }
}
