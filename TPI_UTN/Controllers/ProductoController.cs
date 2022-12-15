using Microsoft.AspNetCore.Mvc;
using practica2.Models;
using System.Diagnostics;
using practica2.Models;
using practica2.Datos;
namespace practica2.Controllers
{
    public class ProductoController : Controller
    {

        //public Producto prod1 = new Producto(010, "Labial MAC", 1200.99m, "MAC", 25 );
        //public Producto prod2 = new Producto(020, "Base NATURA", 1000.99m, "NATURA", 15);
        //public Producto prod3 = new Producto(030, "Mascara de pestañas RIMMEL", 1500.99m, "RIMMEL", 19);
        //public  List<Producto> listaProducto = new List<Producto>()
        //    {
        //        //new Producto(000,"",00.00m,"",0,"",""),
        //        new Producto(010, "Máscara De Pestañas Maybelline Lash Sensational Sky High", 3975.99m, "MAYBELLINE", 25, "TODOS NUESTROS PRODUCTOS SON ORIGINALES E IMPORTADOS POR LOREAL ARGENTINA AL PAÍS. CUENTAN CON LA GARANTÍA OFICIAL Y CUMPLEN TODOS LOS ESTÁNDARES DE CALIDAD.\r\n\r\nVERY BLACK WATERPROOF: A prueba de Agua.\r\nVERY BLACK WASHABLE: Fácil de retirar - NO es a prueba de agua.\r\n\r\nIMPORTANTE: Los productos no vienen con faja de seguridad por formato de ingreso al país cumpliendo con las regulaciones de ANMAT\r\n\r\nEfecto alargamiento:\r\nPestañas hasta el cielo con Sky High dando una mirada sensacional desde cualquier ángulo.\r\nLa máscara de pestañas Lash Sensational Sky High proporciona un volumen total y un alargamiento ilimitado.\r\n\r\nCepillo Flex Tower:\r\nEl exclusivo cepillo de silicona Flex Tower se dobla para dar volumen y extender cada pestaña desde la raíz hasta la punta.\r\n\r\nFórmula con extracto de bambú:\r\nSu fórmula con extracto de bambú y fibras extensoras, proporciona unas pestañas más largas, llenas y ligeras, dejándolas sin grumos.\r\n\r\nAprobado por oftalmólogos:\r\nProbado por oftalmólogos, apto para ojos sensibles y usuarios de lentes de contacto. Se elimina fácilmente con un desmaquillante de ojos.\r\n\r\n¿Cómo usar o aplicar?\r\nPara obtener los mejores resultados, sujeta el cepillo flexible de la máscara Maybelline Lash Sensational Sky High contra las pestañas y extiéndelas desde la raíz hasta la punta repetidamente hasta conseguir el volumen y la longitud deseada.\r\n\r\nSi sufrís de irritaciones o comezón en los ojos cuando te maquillás, esta máscara es para vos. Gracias a sus componentes naturales que no provocan residuos, te ayudará a reducir o eliminar las molestias y a cuidar tu salud ocular.\r\n\r\nCon esta máscara, podrás definir y resaltar tus pestañas. ¡Elegir nunca fue tan fácil!", "https://http2.mlstatic.com/D_NQ_NP_904498-MLA49736531282_042022-O.webp"),
        //        new Producto(020, "Delineador De Ojos Líquido Regina Pluma De Precisión", 1229.00m, "REGINA", 15, "PLUMA®\r\nDelineador de ojos líquido Negro Satinado\r\n\r\n-- Resistente al agua\r\n-- Punta de precisión\r\n-- Larga duración\r\n-- Intransferible\r\n-- Sin fragancia\r\n\r\nTesteado dermatológicamente\r\n100% Vegano Libre de Crueldad Animal #CrueltyFree\r\n\r\nIngredientes: Water (aqua), Acrylates Copolymer, Propylene glycol, PEG-40 hydrogenated, castor oil, Caprylyl Glycol/Phenoxyethanol, Laureth-4, Ethylhexylglycerin, Bisabolol, Disodium, EDTA, Xanthan Gum. Puede contener: CI15850, CI77266, CI19140. Libre de parabenos. Contenido neto 0,8ml. Industria Argentina. Vencimiento 07/2024","https://http2.mlstatic.com/D_NQ_NP_609047-MLA51715684948_092022-O.webp"),
        //        new Producto(030, "Vitamina C | Fresh Serum", 2659.99m, "REGINA", 19,"VITAMINA C FRESH SERUM | Regina \r\nFormulado con bioactivos Vitamina C, Argán y Calendula. Este suero está diseñado para que la cara, los ojos y los labios aumenten instantáneamente la luz natural de la piel.\r\n\r\n10% Vitamina C estabilizada para que el activo no se oxide y actúe en la piel\r\n\r\nQue hace?\r\n\r\nUn delicado suero de pura vitamina C que hidrata en el acto. Se absorbe rápidamente y mejora la luminosidad de la piel. Reduce la apariencia de las arrugas. También ayuda a suavizar la apariencia de signos de envejecimiento alrededor de los ojos y líneas verticales en los labios.\r\n\r\nComo se aplica?\r\n\r\nLuego de su rutina de limpieza diaria con Detox* recomendado. Aplíquese la Vitamina C en la cara y el cuello. Siga con un hidratante si lo desea. \r\n\r\n\r\nIngredientes: Water csp Glycerin, Propylene Glycol,Caprylic/Capric Triglyceride, Behenyl Alcohol (and) Glyceryl Stearate (and) Lecithin (and) Glycine Soja (Soybean) Sterols, Cyclopentasiloxane Calendulaofficinalis (Marigold) flower, Hamamelis Virginiana(Witch Hazel) leaf, Simondsia chinensis (Jojoba) seed oil extract, Argania spinosa (Argan) kernel oil extract ,Imidazolidinyl Urea, Phenoxyethanol (and) Methylparaben (and), Sodium acrylates copolymer and lecithin, Sodium ascorbyl phosphate, BHT, Tetrasodium EDTA, CI 77492. Industria Argentina. Contenido Neto 30 g","https://http2.mlstatic.com/D_NQ_NP_955638-MLA51090386534_082022-O.webp"),
        //        new Producto(040, "Paleta De Sombra Trio Con Filtro Solar Hd Cher The Three", 3816.69m, "CHER", 13,"Paleta de sombras trío con acabado HD. Su formulación presenta un color intenso con pigmentos puros y protección solar. Como posee tecnología HD, este maquillaje ofrece una visibilidad perfecta, los colores se ven intensos, naturales y a la vez, sin exceso de producto. Consejo de uso: con una brocha colocar desde el color más claro a más oscuro. El claro seria para destacar la parte alta de parpado (debajo de la ceja), el tono intermedio en el parpado móvil y el tono mas oscuro puede utilizarse para delinear o en el caso de un make up intenso marcar profundidad. Producto libre de parabenos, testeado dermatológicamente, alta tolerancia en pieles sensibles. No testeado en animales.\r\n\r\nCHER BEAUTY es la primera marca de indumentaria femenina en completar su propuesta de valor lanzando tres ejes DE BELLEZA: make up, skincare y fragancias. Vendemos productos pensados para la mujer argentina y de la región. CHER MAKE UP es una línea cuyo catálogo está diseñado para las necesidades de la mujer actual, tomando como referencia su estilo de vida, las tendencias, sus costumbres y sus necesidades . CHER MAKE UP tiene una composición de colores, texturas y acabados con tecnologías avanzadas desde HD hasta protección y componentes antioxidantes, convirtiéndose así en la primera línea nacional de belleza que está a la altura en calidad de una línea cosmética de lujo.","https://http2.mlstatic.com/D_NQ_NP_712374-MLA52321245879_112022-O.webp"),
        //        new Producto(050,"Labial MAC Matte Lipstick color lady danger",8670.00m,"MAC",155,"Sé protagonista con la ayuda del labial MAC. Para el día o la noche, con un nude delicado o un rojo vibrante, viví el color sin necesidad de retoques. ¡Son perfectos para cualquier ocasión!\r\n\r\nResaltá tu boca\r\nSu presentación en barra aporta un acabado cremoso y sin grumos. Para lograr una boca perfecta, utilizá la punta del labial para contornear y delinear los bordes, esto le dará un efecto de mayor volumen. Luego, rellená con la base plana de la barra desde el centro hacia los extremos, repitiendo el movimiento hasta obtener la intensidad deseada. ¡Ya estás lista para lucir tu labial preferido!","https://http2.mlstatic.com/D_NQ_NP_960965-MLA40244990221_122019-O.webp"),
        //        new Producto(060,"Sombra Mac Eye Shadow Brown Script",7573.50m,"MAC",95,"Sombra de ojos de alta pigmentación y duración, con fórmula fácil de difuminar que permite crear looks profesionales.\r\nSu fórmula de alta duración contiene pigmentos micronizados que brindan alta saturación de color, se adhieren a la piel y permiten difuminar fácilmente para lograr looks profesionales.","https://http2.mlstatic.com/D_NQ_NP_682016-MLA50735345421_072022-O.webp"),
        //    };

        ProductoDatos productoDatos = new ProductoDatos();
        

        public IActionResult Index()
        {
            var listaProducto = productoDatos.Listar();
            return View(listaProducto);
        }

        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Producto producto)
        {
            var respuesta = productoDatos.Guardar(producto);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Editar(int id)
        {
            var producto = productoDatos.Obtener(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            var respuesta = productoDatos.Editar(producto);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int id)
        {
            var producto = productoDatos.Obtener(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Eliminar(Producto producto)
        {
            var respuesta = productoDatos.Eliminar(producto.id);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}