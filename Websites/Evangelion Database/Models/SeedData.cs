using Microsoft.EntityFrameworkCore;

namespace EvangelionDatabase.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EVAContext(
                serviceProvider.GetRequiredService<DbContextOptions<EVAContext>>()
            ))
            {
                if (context.Evangelion.Any())
                {
                    return;
                }

                List<Evangelion> evangelions = new List<Evangelion>{
                    new Evangelion
                    {
                        EVAName = "Evangelion Unit-00",
                        Description = "Evangelion Unit-00 (エヴァンゲリオン零号機, Evangerion Zerogōki?) is the first functional Evangelion unit created, serving as the prototype for the rest of the Evangelion series. It is piloted by Rei Ayanami.",
                        Picture = "EVA00.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Unit-01",
                        Description = "Evangelion Unit-01 (エヴァンゲリオン初号機, Evangerion Shogōki?) is the first non-prototype Evangelion unit, and is referred to as the \"EVA-01 TEST TYPE\". It houses the soul of Shinji's mother, Yui Ikari. It is mainly piloted by Shinji Ikari. Unit-01 serves as the flagship model for the series.",
                        Picture = "EVA01.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Unit-02",
                        Description = "Evangelion Unit-02 (エヴァンゲリオン 弐号機, Evangerion Nigōki?) is the third Evangelion completed, the first Production Model Evangelion. The design of Unit-02 supposedly rectifies the mistakes made during the construction of Prototype Unit-00 and Test Type Unit-01, making it the first Evangelion built specifically for combat against the Angels. It is piloted by Asuka Langley Sohryu and briefly by Kaworu Nagisa.",
                        Picture = "EVA02.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Unit-03",
                        Description = "Evangelion Unit-03 (エヴァンゲリオン 3号機, Evangerion Sangōki?) is an Evangelion Unit that never sees action before being possessed by Bardiel in Episode 17 of Neon Genesis Evangelion. It was piloted by Tōji Suzuhara.",
                        Picture = "EVA03.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Unit-04",
                        Description = "Evangelion Unit-04 (エヴァンゲリオン 4号機, Evangerion Yongōki?) was an Evangelion model developed in the United States. While Unit-04 is never seen in the series, promotional materials and other appearances make it appear to be a silver or chrome version of Evangelion Unit-03.",
                        Picture = "EVA04.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Mass Production Evangelions",
                        Description = "Mass Production Evangelions (エヴァンゲリオン量産機, Evangerion Ryōsanki?) are the final Evangelion units to be produced, appearing in the The End of Evangelion film. They were manufactured in secrecy under SEELE's mandate at seven different NERV facilities around the world, including ones in Germany and China.",
                        Picture = "MassProduct.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Proto Type-00",
                        Description = "Evangelion Unit-00 (零号機, Zerogōki?, lit. \"Unit Zero\") is an Evangelion unit appearing in Rebuild of Evangelion film series. It was piloted by Rei Ayanami, it is the first functional Evangelion unit ever created.",
                        Picture = "EVA00Proto.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Test Type-01",
                        Description = "Evangelion Unit-01 (初号機, Shogōki?, lit. \"First Unit\") is an Evangelion unit appearing in the Rebuild of Evangelion film series. First appearing in Evangelion: 1.0 You Are (Not) Alone, it is piloted by Shinji Ikari.",
                        Picture = "EVA01Test.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Production Model-02",
                        Description = "Evangelion Unit-02 (2号機, Nigōki?, lit. \"Unit Two\") is an Evangelion unit appearing in Rebuild of Evangelion film series. It first appears in Evangelion: 2.0 You Can (Not) Advance, piloted by Asuka Shikinami Langley, as well as briefly by Mari Makinami Illustrious during the battle against the Tenth Angel.",
                        Picture = "EVA02Product.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Production Model-03",
                        Description = "Evangelion Unit-03 (3号機, Sangōki?, lit. \"Unit Three\"), is an Evangelion unit appearing in Rebuild of Evangelion film series. Appearing for the first and only time in Evangelion: 2.0 You Can (Not) Advance, it is the second \"Production Model\". This Evangelion was piloted once by Asuka Shikinami Langley during its activation test but never sees actual action before being possessed by the Ninth Angel.",
                        Picture = "EVA03Product.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Next Gen Testbed-04",
                        Description = "Evangelion Next Gen Testbed-04 (汎用ヒト型決戦兵器 人造人間エヴァンゲリオン 次世代試験4号機?) is an Evangelion unit in the Rebuild of Evangelion film series. It is only mentioned in Evangelion: 2.0 You Can (Not) Advance.",
                        Picture = "EVA04Test.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Provisional Unit-05",
                        Description = "Evangelion Provisional Unit-05 (仮設5号機, Kasetsu Gogōki?, lit. \"Hypothetical Unit Five\") is an Evangelion Unit belonging to the Rebuild of Evangelion film series. It is an Evangelion unit introduced in Evangelion: 2.0 You Can (Not) Advance.",
                        Picture = "EVA05Pro.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Production Model Custom Type-08α",
                        Description = "Evangelion Production Model Custom Type-08α (汎用ヒト型決戦兵器 人造人間エヴァンゲリオン 正規実用型（ヴィレカスタム） 8号機α, Hanyō Hitogata Kessen Heiki Jinzō Ningen Evangerion Seiki Jitsuyōgata (Vire Kasutamu) Hachigōki Arufa?, lit. \"General-Purpose Humanoid Battle Weapon Android Evangelion Utility Model (WILLE Custom) Unit Eight Alpha\") is an Evangelion Unit belonging to the Rebuild of Evangelion film series. It appears briefly in Evangelion: 3.0 You Can (Not) Redo, the Unit is piloted by Mari Makinami Illustrious and is fighting alongside the Evangelion Production Model-02'β, against the Evangelion Mark.04 during the Operation US.",
                        Picture = "EVA08Alpha.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Mark.04A",
                        Description = "Evangelion Mark.04A (EVANGELION Mark.04A, Evangerion Māku Fō Ei?) is an Evangelion unit introduced in the Rebuild of Evangelion film series. It is an autonomous Evangelion unit introduced in Evangelion: 3.0 You Can (Not) Redo. Mark.04A is first seen serving as a defense mechanism for the Tesseract to prevent its retrieval by Evangelion Unit-02'β during the Operation US.",
                        Picture = "EVAMark04.png"
                    },
                    new Evangelion
                    {
                        EVAName = "Evangelion Mark.04B",
                        Description = "Evangelion Mark.04B (EVANGELION Mark.04B, Evangerion Māku Fō Bi?) is an Evangelion unit introduced in the Rebuild of Evangelion film series. It is an autonomous Evangelion unit introduced in Evangelion: 3.0 You Can (Not) Redo. Mark.04B is seen serving as a defense mechanism for the Tesseract to act as a defensive system. It tries to prevent its retrieval by Evangelion Unit-02'β during the Operation US.",
                        Picture = "EVAMark04B.png"
                    }
                };
                context.AddRange(evangelions);

                List<Pilot> pilots = new List<Pilot>{
                    new Pilot
                    {
                        FirstName = "Rei",
                        LastName = "Ayanami",
                        Description = "Rei Ayanami (綾波 レイ/あやなみ れい/アヤナミ レイ), Ayanami Rei?) is a fictional character from the Neon Genesis Evangelion franchise. She is the First Child (referred as the First Children in the Japanese version), the pilot of Evangelion Unit-00 and one of the central characters.",
                        Picture = "Rei.png"
                    },
                    new Pilot
                    {
                        FirstName = "Shinji",
                        LastName = "Ikari",
                        Description = "Shinji Ikari (碇シンジ, Ikari Shinji?)[2] is the Third Child, the main protagonist of the series and the designated pilot of Evangelion Unit-01. He is the son of Gehirn bioengineer Yui Ikari and NERV Commander (formerly Chief of Gehirn) Gendo Ikari. After his mother's death, he was abandoned by his father and lived for 11 years with his sensei, until he was summoned to Tokyo-3 to pilot Unit-01 against the Angels. He lives initially just with Misato Katsuragi; they are later joined by Asuka Langley Soryu.",
                        Picture = "Shinji.png"
                    },
                    new Pilot
                    {
                        FirstName = "Asuka",
                        LastName = "Langley Soryu",
                        Description = "Asuka Langley Sohryu (惣流・アスカ・ラングレー, Sōryū Asuka Rangurē?) is a 14-year-old fictional character from the Neon Genesis Evangelion franchise and one of the main female characters. Asuka is designated as the Second Child (\"Second Children\" in the original Japanese versions) of the Evangelion Project and pilots the Evangelion Unit-02. Her surname is romanized as Soryu in the English manga and Sohryu in the English version of the TV series, the English version of the anime movie, and on Gainax's website.",
                        Picture = "Asuka.png"
                    },
                    new Pilot
                    {
                        FirstName = "Tōji",
                        LastName = "Suzuhara",
                        Description = "Tōji Suzuhara (鈴原 トウジ, Suzuhara Tōji?) is a fictional character from the Neon Genesis Evangelion franchise. He is the Fourth Child (Fourth Children in the Japanese version), selected to be the pilot of Evangelion Unit-03.",
                        Picture = "Toji.png"
                    },
                    new Pilot
                    {
                        FirstName = "Missing",
                        LastName = "Pilot",
                        Description = "Placeholder for pilots who have either not been mentioned in the Neon Genesis Evangelion franchise, or for pilots that have manned an EVA but do not ever get mentioned in the story (aka background characters).",
                        Picture = "Missing.jpeg"
                    },
                    new Pilot
                    {
                        FirstName = "Dummy",
                        LastName = "System",
                        Description = "The Dummy System is a special system implemented into Dummy Plugs (ダミープラグ?) which are Entry Plugs modified to work with the dummy system.",
                        Picture = "Dummy.png"
                    },
                    new Pilot
                    {
                        FirstName = "Mari",
                        LastName = "Makinami Illustrious",
                        Description = "Mari Makinami Illustrious (真希波・マリ・イラストリアス, Makinami Mari Irasutoriasu?) is a fictional character from the Rebuild of Evangelion film series. She is an Evangelion pilot and third party operative introduced in Evangelion: 2.0 You Can (Not) Advance.",
                        Picture = "Mari.png"
                    },
                };
                context.AddRange(pilots);

                List<PilotEvangelions> assignedEVA = new List<PilotEvangelions>{
                    new PilotEvangelions {EvangelionID = 1, PilotID = 1},
                    new PilotEvangelions {EvangelionID = 2, PilotID = 2},
                    new PilotEvangelions {EvangelionID = 3, PilotID = 3},
                    new PilotEvangelions {EvangelionID = 4, PilotID = 4},
                    new PilotEvangelions {EvangelionID = 5, PilotID = 5},
                    new PilotEvangelions {EvangelionID = 6, PilotID = 6},
                    new PilotEvangelions {EvangelionID = 7, PilotID = 1},
                    new PilotEvangelions {EvangelionID = 8, PilotID = 2},
                    new PilotEvangelions {EvangelionID = 9, PilotID = 3},
                    new PilotEvangelions {EvangelionID = 10, PilotID = 3},
                    new PilotEvangelions {EvangelionID = 11, PilotID = 5},
                    new PilotEvangelions {EvangelionID = 12, PilotID = 7},
                    new PilotEvangelions {EvangelionID = 13, PilotID = 7},
                    new PilotEvangelions {EvangelionID = 14, PilotID = 5},
                    new PilotEvangelions {EvangelionID = 15, PilotID = 5}
                };
                context.AddRange(assignedEVA);

                context.SaveChanges();
            }
        }
    }
}