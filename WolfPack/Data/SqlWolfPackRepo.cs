using System;
using System.Collections.Generic;
using System.Linq;
using WolfPack.Models;

namespace WolfPack.Data
{
    public class SqlWolfPackRepo : IWolfPackRepository
    {
        private readonly WolvesContext _context;

        public SqlWolfPackRepo(WolvesContext context)
        {
            _context=context;
        }

        public void CreatePack(Pack pack)
        {
            if(pack==null)
            {
                throw new ArgumentNullException(nameof(pack));
            }
            _context.Packs.Add(pack);
        }

        public void CreateWolf(Wolf wolf)
        {
            if(wolf==null)
            {
                throw new ArgumentNullException(nameof(wolf));
            }
            _context.Wolves.Add(wolf);
        }

        public void DeletePack(Pack pack)
        {
            if(pack==null)
            {
                throw new ArgumentNullException(nameof(pack));
            }
            _context.Packs.Remove(pack);
        }

        public void DeleteWolf(Wolf wolf)
        {
            if(wolf==null)
            {
                throw new ArgumentNullException(nameof(wolf));
            }
            _context.Wolves.Remove(wolf);
        }

        public Pack GetPackById(int id)
        {
            return _context.Packs.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pack> GetPacks()
        {
            return _context.Packs.ToList();
        }

        public Wolf GetWolfById(int id)
        {
            return _context.Wolves.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Wolf> GetWolves()
        {
            return _context.Wolves.ToList();
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges()>=0);
        }

        public void UpdatePack(Pack pack)
        {
            //nothing
        }

        public void UpdateWolf(Wolf wolf)
        {
            //nothing
        }
    }
}