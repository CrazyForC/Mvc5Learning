using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorTest
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Tele { get; set; }
        public string Addr { get; set; }
    }

    class UserList : IEnumerable
    {
        public User[] Users { get; set; }
        public IEnumerator GetEnumerator()
        {
            return new UserListEnumerator(this);
        }
    }

    class UserListEnumerator : IEnumerator
    {
        UserList userList;
        int index;
        User currentElement;

        public UserListEnumerator(UserList userList)
        {
            this.userList = userList;
        }

        public object Current => currentElement;

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
