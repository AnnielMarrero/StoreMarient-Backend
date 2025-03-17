using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreMarient.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StoreMarient.Data
{
    public class DbSeeder
    {

        public static async Task SeedAsync(StoreContext context)
        {
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Check if there are already users in the database
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new Category
                {
                    Name = "Miscelaneas"
                },
                new Category
                {
                    Name = "Celulares",
                },
                new Category
                {
                    Name = "Bebidas",
                },
                new Category
                {
                    Name = "Cover",
                },
                new Category
                {
                    Name = "Micas",
                },
                new Category
                {
                    Name = "Confituras",
                },
                new Category
                {
                    Name = "Utiles",
                },
                new Category
                {
                    Name = "Bebe",
                }
                );

                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                string[] productMiscelaneas = {
                    "estropajo aluminio",
"esponja de fragar",
"esponja de colores",
"aplicador de oido",
"fosforera",
"fosforera pistola",
"lapiz de cejas",
"espejuelos graduados",
"gafas de niño",
"espiga corriente",
"Adaptador r/ p",
"adaptador 3 huecos",
"maquina de afeitar",
"incenso de olor",
"incenso citronela",
"juego de cuchillo",
"afilador de cuchillo",
"lapiz infinito",
"lapiz",
"lapiz raya",
"presillas",
"boligrafos",
"sit de escuela tijeras",
"set escuela agenda",
"cartucheras",
"medias de escuela",
"plantillas",
"regla",
"tinte de pelo",
"condones",
"peineta piojos",
"tina led sm",
"pegamento pomo",
"pegamento super blue",
"intimas",
"lima uñas",
"piña ambientador",
"marbelline",
"brillo liso",
"delineador 360 h",
"creyones lapiz",
"creyones brocha",
"desodorante obao",
"desodorante sray obao",
"desodorante sray lady spead",
"desodorante gillete",
"pega mosca",
"pega rata",
"linterna amarilla",
"bobillo de 75 w",
"borra led grande",
"respuesto cuter",
"bandas electriccas",
"presinta transparente",
"jabon de lavar bodeg",
"jabon de baño bodeg",
"jabon de baño 100 g",
"jabon de lavar liz",
"betun negro",
"pesa digital",
"timbre inalambrico",
"short negro mujer",
"papel higienico",
"paleta de maquillaje",
"colonias",
"comparto maquillaje",
"billeteras",
"moco golira grande",
"flor de baño",
"pasta colgate",
"pasta crest",
"repuesto cuter",
"lampara cuadrada",
"ventilador panel",
"linterna blanca",
"ventilador grande",
"extencion",
"resistencia"
                };
                foreach (var product in productMiscelaneas)
                {
                    context.Products.Add(new Product { Name = product, Quantity = 0, CategoryId = 1 });
                }

                string[] bebidas = {
                    "cerveza cristal",
"cerveza cristal extra",
"cerveza mayabe",
"cerveza coralday",
"cerveza bucanero",
"cerveza unlargar",
"cerveza wuillmill",
"energizante twsw",
"jugo estrella aquel",
"jugo manzana",
"jugo uva",
"jugo naranja  yei",
"jugo coctel yei",
"fugo grande",
"malta perla negra",
"malta belga",
"malta hyper",
"lata cm cola",
"lata cm naranja",
"lata cm limon",
"pomo refersco grande",
"malta bucanero",
"ron especial",
"ron 3 años",
"lata piñita",
"pomo chico cola cm",
"pomo chico mate cm",
"pomo chico limon cm",
"energizante power",
"lata 7 limon",
"lata santa limon",
"cerveza lander brau",
"pomo refresco pool"

                };

                foreach (var bebida in bebidas)
                {
                    context.Products.Add(new Product { Name = bebida, Quantity = 0, CategoryId = 3 });
                }

                string[] confituras = {
                    "cupa chupa g",
"nurix",
"mega",
"my bar",
"rockbar",
"stort",
"canita",
"bombones",
"pelli de queso",
"gallt brinky",
"galt trio",
"greedy",
"pelli de jamon",
"peter total",
"bite cake",
"cikilap",
"papas anduladas",
"papas ancho",
"piñatera",
"caramelos",
"chicles",
"chupas pequeños",
"wow",
"pandora",
"beste",
"tanch duo",
"elvaren",
"mooiste",
"moweix",
"galletas bisroll",
"galletas petez",
"tacos soda",
"panque gewards",
"panques frutas",
"panques choco cake",
"panques snow",
"choco paris",
"niks",
"peter milano",
"panque porleo azul",
"panque porkeo rojo",
"panque noby",
"limausere",
"shine",
"pasta de tomates",
"mayonesa",
"leche condensada",
"espaguetis",
"café pura sangre",
"café aroma",
"sopas intantaneas",
"refresco paq 2 lt",
"chupa medianos",
"sobres tomates"};
                foreach (var confitura in confituras)
                {
                    context.Products.Add(new Product { Name = confitura, Quantity = 0, CategoryId = 6 });
                }

                string[] utiles = {
                    "cartera lazo",
"bolsitos 4000",
"cartera 3 piezas",
"polso playa",
"bolso letras redondo",
"juego de mochilas",
"perf mediano",
"mala madre",
"set perfumes 3 piezas",
"alfileres",
"pinzas de cejas",
"carterita juguetes",
"bolso azul cuadrado",
"bolsito mediano",
"mochila azul",
"bolso transparente",
"bolso pink",
"bolso lona",
"mochila tematica  3 piezas",
"mochila muñeco",
"muñeca de trapo",
"espadas",
"monedero unicornio",
"tinte + peroxido",
"lazo chino",
"pizarra",
"set cocinita"};

                foreach (var util in utiles)
                {
                    context.Products.Add(new Product { Name = util, Quantity = 0, CategoryId = 7 });
                }

                string[] bebes = {

                    "bata de baño",
"malla palangana",
"set de peine y sepilloo",
"set de 4 brochas cuna",
"set de 2 medias",
"pares de medias",
"zapato corte nuevo",
"zapato beich",
"zapato azul",
"zapatos",
"sabanas de cuna",
"3 sabanas maises 2000",
"overol mezclilla",
"set short + tirantes y lazo"

                };
                foreach (var bebe in bebes)
                {
                    context.Products.Add(new Product { Name = bebe, Quantity = 0, CategoryId = 8 });
                }

                await context.SaveChangesAsync();

            }
            if (!context.Pieces.Any())
            {
                string[] piezas = {
                    "Cables",
                    "CARGADOR",
                    "ADAPTADORES",
                    "manillas",
                    "MEMORIA Usb",
                    "MSD",
                    "audifonos",
                    "Arañitas"
                };
                foreach (var pieza in piezas)
                {
                    context.Pieces.Add(new Piece { Name = pieza });
                }
                await context.SaveChangesAsync();
                // adicionando modelos a las piezas
                string[] models = {
                    "CD Iph",
                    "CD TIPO C",
                    "CD V8",
                    "CD TC/TC",
                    "HDMI 1,5m",
                    "RCA",
                    "mini plu-RCA",
                    "3.0",
                    "PLUS/PLUS",
                    "EXTENSOR USB"
                };
                int pieceId = 1;
                foreach (var model in models)
                {
                    context.Phones.Add(new Phone { Model = model, PieceId = pieceId, Quantity = 0 });
                }

                //----------------------------------------
                models = new string[] {
                    "caja ip 1Hora",
                    "caja t/c 1Hora",
                    "caja v8 1Hora",
                    "samsung 25w",
                    "samsung 45w",
                    "30W TC/TC",
                    "30W TC/IPH",
                    "piñas 3,1"
                };
                pieceId++;
                foreach (var model in models)
                {
                    context.Phones.Add(new Phone { Model = model, PieceId = pieceId, Quantity = 0 });
                }
                //----------------------------------------
                models = new string[] {
                    "OTG V8",
                    "OTG TIPO C",
                    "EXTENSION USB 4 PORT+ TC",

                };
                pieceId++;
                foreach (var model in models)
                {
                    context.Phones.Add(new Phone { Model = model, PieceId = pieceId, Quantity = 0 });
                }
                //----------------------------------------
                models = new string[] {
                    "apple",
                    "miband 5/6",
                    "miband 3/4 negra",
                    "reloj niño",
                };
                pieceId++;
                foreach (var model in models)
                {
                    context.Phones.Add(new Phone { Model = model, PieceId = pieceId, Quantity = 0 });
                }

                //----------------------------------------
                models = new string[] {
                    "64 GB",
                    "32 GB",
                    "16 GB",
                    "FLASH DRIVE 16GB"
                };
                pieceId++;
                foreach (var model in models)
                {
                    context.Phones.Add(new Phone { Model = model, PieceId = pieceId, Quantity = 0 });
                }

                //----------------------------------------
                models = new string[] {
                    "64 GB"
                };
                pieceId++;
                foreach (var model in models)
                {
                    context.Phones.Add(new Phone { Model = model, PieceId = pieceId, Quantity = 0 });
                }
                //----------------------------------------
                models = new string[] {
                    "1hora",
                    "AKG",
                    "ML",
                    "cascos"

                };
                pieceId++;
                foreach (var model in models)
                {
                    context.Phones.Add(new Phone { Model = model, PieceId = pieceId, Quantity = 0 });
                }
                //----------------------------------------
                models = new string[] {
                    "Arañitas",
                    "CARGADOR PORTATIL 10000mAh",
                    "CARGADOR PORTATIL 20000mAh",
                    "mause 1 hora",
                    "cargador portatil moreka",
                    "ptotector voltage",
                    "reloj t55"
                };
                pieceId++;
                foreach (var model in models)
                {
                    context.Phones.Add(new Phone { Model = model, PieceId = pieceId, Quantity = 0 });
                }
                await context.SaveChangesAsync();
            }
            if (!context.PhoneTypes.Any())
            {
                string[] phoneTypes = {
                    "SAMSUNG",
                    "IPHONE",
                    "XIAOMI",
                    "motorola",
                    "huawei"
                };
                foreach (var phoneType in phoneTypes)
                {
                    context.PhoneTypes.Add(new PhoneType { Name = phoneType });
                }
                await context.SaveChangesAsync();
            }

            if (!context.Micas.Any())
            {
                //-------------------------------------------
                string[] micas = {
                    "a10",
                    "a05/13c",
                    "a15",
                    "a20",
                    "j2 prime/g530",
                    "a21s"
                };
                int phoneTypeId = 1;
                foreach (var mica in micas)
                {
                    context.Micas.Add(new Mica { Model = mica, PhoneTypeId = phoneTypeId });
                }
                //-------------------------------------------
                micas = new string[]{
                    "I6/7/8 trasp",
                    "i7+/8+",
                    "x / xs",
                    "XsMAX / 11 pro max",
                    "I 12 PRO MAX",
                    "13/14",
                    "13 pro max",
                };
                phoneTypeId++;
                foreach (var mica in micas)
                {
                    context.Micas.Add(new Mica { Model = mica, PhoneTypeId = phoneTypeId });
                }
                //-------------------------------------------
                micas = new string[]{
                    "9a",
                    "note 13",
                    "note 9"
                };
                phoneTypeId++;
                foreach (var mica in micas)
                {
                    context.Micas.Add(new Mica { Model = mica, PhoneTypeId = phoneTypeId });
                }
                
                await context.SaveChangesAsync();
            }

            if (!context.CoverTypes.Any())
            {
                string[] coverTypes = {
                    "reborde",
                    "sencillos",
                    "roboticos"
                };
                foreach (var coverType in coverTypes)
                {
                    context.CoverTypes.Add(new CoverType { Name = coverType });
                }
                await context.SaveChangesAsync();
            }

            if (!context.Covers.Any())
            {
                //-------------------------------------------
                string[] models = {
                    "IXS MAX",
                    "i 11",
                    "11 pro",
                    "i 11 PRO max",
                    "12",
                    "12 pro",
                    "12 pro max",
                    "13 mini",
                    "13",
                    "13 pro",
                    "13 pro max",
                    "14",
                    "14 pro max",
                    "14 pro",
                    "14 plus",
                    "x",
                    "xr",

                };
                int phoneTypeId = 2;
                foreach (var model in models)
                {
                    context.Covers.Add(new Cover { Model = model, PhoneTypeId = phoneTypeId });
                }
                //-------------------------------------------
                models = new string []{
                    "a20 / a30",
                    "a20s",
                    "a50 / a30s",
                    "a13 / a23",
                    "f13",
                    "a03",
                    "a21s",
                    "a31",
                    "a51",
                    "j2",
                    "a15",
                    "j4",
                    "j7",
                    "a04",
                    "a04s",
                    "a52",
                    "a22 4g",
                    "a22 5g",
                    "a32",
                    "a14",
                    "a02",
                    "j6plus / j4 +",
                    "a34 5g",
                    "a71",
                    "a05s",
                    "a05",
                    "s23 u",
                    "s24u",
                    "a02s",
                    "j7p",
                    "j6plus",
                    "j2 plus",
                    "a 23 5g",
                };
                phoneTypeId = 1;
                foreach (var model in models)
                {
                    context.Covers.Add(new Cover { Model = model, PhoneTypeId = phoneTypeId });
                }
                //-------------------------------------------
                models = new string [] {
                    "9a",
                    "9c/10a",
                    "10C",
                    "NOTE 9",
                    "9t",
                    "RM 9",
                    "a3",
                    "12c",
                    "note11",
                     "NOTE 10 4g",
                     "NOTE 10 5g",
                     "NOTE 10 pro 4g",
                    "redmi 10 c",
                    "NOTE 11 global",
                    "NOTE 11 4g",
                    "NOTE 11 5g",
                    "note 124 g",
                    "a1 plus",
                    "note 9 pro 4 g",
                    "note 9 pro 5 g",
                    "note 9",
                    "note 11 pro 4g",
                    "note 11 pro 5g",
                    "a 1",
                    "redmi 10",
                    "13c",
                    "note 13 5g",
                    "note 12 4g"
                };
                phoneTypeId = 3;
                foreach (var model in models)
                {
                    context.Covers.Add(new Cover { Model = model, PhoneTypeId = phoneTypeId });
                }
                //-------------------------------------------
                models = new string[]{
                    "m-651",
                    "e30/e40 4g",
                    "canion 20 4g",
                    "e51/g31",

                };
                phoneTypeId = 4;
                foreach (var model in models)
                {
                    context.Covers.Add(new Cover { Model = model, PhoneTypeId = phoneTypeId });
                }

                await context.SaveChangesAsync();
            }

            if (!context.CoverStocks.Any())
            {
                int[] coversId = (await context.Covers.ToListAsync()).Select(_ => _.Id).ToArray();
                int[] coverTypesId = (await context.CoverTypes.ToListAsync()).Select(_ => _.Id).ToArray();

                foreach (int coverId in coversId)
                {
                    foreach (var coverTypeId in coverTypesId)
                    {
                        context.CoverStocks.Add(new CoverStock { CoverId = coverId,  CoverTypeId = coverTypeId, Quantity = 0 });
                    }
                }
                await context.SaveChangesAsync();
            }
        }

    }
}
