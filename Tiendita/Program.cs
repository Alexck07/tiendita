using System;
using System.Linq;
using Tiendita.models;

namespace Tiendita
{
    class Program
    {
        static void Main(string[] args)
        {

            login();
        }

        public static void login()
        {

            Console.WriteLine("Iniciar sesión");


            Console.WriteLine("Escribe nombre de usuario:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escribe contraseña de usuario:");
            string contrasenia = Console.ReadLine();

            string contrasenia1 = Encrypt.GetSHA256(contrasenia);


            using (TienditaContext context = new TienditaContext())
            {
                Usuarios usuario = context.Usuarios.Where(a => a.Nombre == nombre && a.Contrasenia == contrasenia1).FirstOrDefault();

                if (usuario != null)
                {
                    Menu();

                }
                else
                {
                    Console.WriteLine("Usuario no encontrado");
                }


            }
        }

        public static void Menu()
        {
          
            Console.WriteLine("1) Registrar nuevo usuario");
            Console.WriteLine("2) Buscar producto");
            Console.WriteLine("3) Crear producto");
            Console.WriteLine("4) Actualizar producto");
            Console.WriteLine("5) Eliminar producto");
            Console.WriteLine("6) Buscar usuarios");
            Console.WriteLine("7) Eliminar usuario");
            Console.WriteLine("0) Salir");
            Console.WriteLine("Escribe la opción: ");

            string opcion = Console.ReadLine();
            switch (opcion)
            {

                case "1":
                    Registrarse();
                    break;
                case "2":
                    BuscarProductos();
                    break;
                case "3":
                    CrearProducto();
                    break;
                case "4":
                    ActualizarProducto();
                    break;
                case "5":
                    EliminarProducto();
                    break;
                case "6":
                    BuscarUsuarios();
                    break;
                case "7":
                    EliminarUsuario();
                    break;
                case "0": return;
            }
            Menu();

        }

        public static void Registrarse()
        {

            Console.WriteLine("        REGISTRARSE        ");
            Usuario = new Usuarios();
            usuario = LlenarUsuario(usuario);

            using (TienditaContext context = new TienditaContext())
            {
                context.Add(usuario);
                context.SaveChanges();
                Console.WriteLine("Usuario creado con exito");
            }

        }

        public static void BuscarProductos()
        {
            Console.WriteLine(" BUSCAR PRODUCTOS");
            Console.Write("Buscar: ");
            string buscar = Console.ReadLine();

            using (TienditaContext context = new TienditaContext())
            {
                IQueryable <Producto> productos = context.Productos.Where(p => p.Nombre.Contains(buscar));
                foreach (Producto producto in productos)
                {
                    Console.WriteLine(producto);
                }
            }
        }
        public static void BuscarUsuarios()
        {
            Console.WriteLine("            BUSCAR USUARIOS           ");
            Console.Write("Buscar: ");
            string buscar = Console.ReadLine();

            using (TienditaContext context = new TienditaContext())
            {
                IQueryable<Usuarios> usuarios = context.Usuarios.Where(p => p.Nombre.Contains(buscar));
                foreach (Usuarios usuario in usuarios)
                {
                    Console.WriteLine(usuario);
                }
            }
        }


        public static void CrearProducto()
        {
            Console.WriteLine("Crear producto");
            Producto producto = new Producto();
            producto = LlenarProducto(producto);

            Console.Write("Nombre: ");
            producto.Nombre = Console.ReadLine();
            Console.Write("Descripción: ");
            producto.Descripcion = Console.ReadLine();
            Console.Write("Precio: ");
            producto.Precio = decimal.Parse(Console.ReadLine());
            Console.Write("Costo: ");
            producto.Costo = decimal.Parse(Console.ReadLine());
            Console.Write("Cantidad: ");
            producto.Cantidad = decimal.Parse(Console.ReadLine());
            Console.Write("Tamaño: ");
            producto.Tamano = Console.ReadLine();

            using (TienditaContext context = new TienditaContext())
            {
                context.Add(producto);
                context.SaveChanges();
                Console.WriteLine("producto creado");
            }
        }

        public static Producto LlenarProducto(Producto producto)
        {
            
            Console.Write("Nombre: ");
            producto.Nombre = Console.ReadLine();
            Console.Write("Descripción: ");
            producto.Descripcion = Console.ReadLine();
            Console.Write("Precio: ");
            producto.Precio = decimal.Parse(Console.ReadLine());
            Console.Write("Costo: ");
            producto.Costo = decimal.Parse(Console.ReadLine());
            Console.Write("Cantidad: ");
            producto.Cantidad = decimal.Parse(Console.ReadLine());
            Console.Write("Tamaño: ");
            producto.Tamano = Console.ReadLine();
            return producto;
        }
        public static Producto SelecionarProducto()
        {
            BuscarProductos();
            Console.Write("Seleciona el código de producto: ");
            uint id = uint.Parse(Console.ReadLine());
            using (TienditaContext context = new TienditaContext())
            {
                Producto producto = context.Productos.Find(id);
                if (producto == null)
                {
                    SelecionarProducto();
                }
                return producto;
            }
        }
        public static Usuarios SelecionarUsuario()
        {
            BuscarUsuarios();
            Console.Write("Seleciona el id de usuario: ");
            uint id = uint.Parse(Console.ReadLine());
            using (TienditaContext context = new TienditaContext())
            {
                Usuarios usuario = context.Usuarios.Find(id);
                if (usuario == null)
                {
                    SelecionarUsuario();
                }
                return usuario;
            }
        }

        public static void ActualizarProducto()
        {
            Console.WriteLine("Actualizar producto");
            Producto producto = SelecionarProducto();
            producto = LlenarProducto(producto);
            using (TienditaContext context = new TienditaContext())
            {
                context.Update(producto);
                context.SaveChanges();
                Console.WriteLine(" Producto actualizado con exito");
            }
        }

        public static void EliminarProducto()
        {
            Console.WriteLine("            ELIMINAR PRODUCTO           ");
            Producto producto = SelecionarProducto();
            using (TienditaContext context = new TienditaContext())
            {
                context.Remove(producto);
                context.SaveChanges();
                Console.WriteLine("Producto eliminado ");
            }
        }
        public static void EliminarUsuario()
        {
            Console.WriteLine("            ELIMINAR USUARIO            ");
            Usuarios usuario = SelecionarUsuario();
            using (TienditaContext context = new TienditaContext())
            {
                context.Remove(usuario);
                context.SaveChanges();
                Console.WriteLine("******* El usuario se ha eliminado con exito *******");
            }
        }
    }
}
