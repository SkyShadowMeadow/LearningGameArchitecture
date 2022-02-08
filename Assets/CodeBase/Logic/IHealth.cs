using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Logic
{
    public interface IHealth
    {
        event Action HealthChanged;
        float Current { get; set; }
        float Max { get; set; }
        void TakeDamage(float damage);
    }
}
