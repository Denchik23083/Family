﻿using Family.Db.Entities;

namespace Family.Http.ChildrenHttpService
{
    public interface IChildrenHttpService
    {
        Task<IEnumerable<Child>> GetAllChildren();

        Task<IEnumerable<Parent>> GetChildrenParents(int childId);

        Task<Child> GetChild(int childId);

        Task CreateChild(Child createdChild);

        Task EditChild(Child editedChild, int childId);

        Task DeleteChild(int childId);
    }
}