using Ls.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Repository
{
    public interface IPlanRepository:IBaseRepository<LearnPlan>
    {

    }
    public class PlanRepository:BaseRepository<LearnPlan>, IPlanRepository
    {
    }
}
