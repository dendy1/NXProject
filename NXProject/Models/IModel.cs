using NXOpen.UF;

namespace NXProject.Models
{
    interface IModel
    {
        void Draw(UFSession session, string filename);
    }
}
