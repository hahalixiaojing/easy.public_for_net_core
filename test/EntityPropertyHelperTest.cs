
namespace ConsoleApplication
{
    public class EntityPropertyHelperTest
    {
        public void SetPropertyTest()
        {
            var p =new Easy.Public.EntityPropertyHelper<Entity>();
            var entity =new Entity();
            p.SetValue(m=>m.Id,entity,100);
        }
    }

    public class Entity
    {
        public int Id { get; protected set; }
    }
}