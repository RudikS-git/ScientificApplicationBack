using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum ApplicationStatesEnum
    {
        Draft = 1, // Черновик
        Checked = 2, // На проверке
        Rejected = 3, // Отклонено
        Modification = 4, // На доработке
        Accepted = 5 // Согласовано
    }
}
