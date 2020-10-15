using System.Collections.Generic;
using WolfPack.Models;
namespace WolfPack.Data
{
    public interface IWolfPackRepository
    {
        bool SaveChanges();
        IEnumerable<Wolf> GetWolves();
        Wolf GetWolfById(int id);
        void CreateWolf(Wolf wolf);
        void UpdateWolf(Wolf wolf);
        void DeleteWolf(Wolf wolf);
        IEnumerable<Pack> GetPacks();
        Pack GetPackById(int id);
        void CreatePack(Pack pack);
        void UpdatePack(Pack pack);
        void DeletePack(Pack pack);
    }
}