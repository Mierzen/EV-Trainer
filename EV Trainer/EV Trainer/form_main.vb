Public Class form_main
    Public tableAllPok As New DataTable
    Public tableBattled As New DataTable
    Dim previousPok As String
    Dim isDirty As Boolean
    Dim saveWasCancelled As Boolean = False
    Dim newHasBeenAdded As Boolean = False

    Private Sub form_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SuspendLayout()

        lb_EnemyHP.Text = ""
        lb_EnemyAtk.Text = ""
        lb_EnemyDef.Text = ""
        lb_EnemySpAtk.Text = ""
        lb_EnemySpDef.Text = ""
        lb_EnemySpd.Text = ""

        lb_TotalPlanned.Text = ""
        lb_TotalCurrent.Text = ""

        createTable()
        battlePokemonList("name")

        saveData.trainPokemonList()
        previousPok = Nothing
        isDirty = False

        SAVEToolStripMenuItem.Enabled = False
        DELETESAVEFILEToolStripMenuItem.Enabled = False
        gb_TrainingPok.Enabled = False
        gb_enemy.Enabled = False

        Dim textboxes = gb_TrainingPok.Controls.OfType(Of TextBox)()
        For Each tb In textboxes
            AddHandler tb.TextChanged, AddressOf tbTextChanged
        Next

        For Each btn In panel_battleBtns.Controls.OfType(Of Button)()
            AddHandler btn.MouseDown, AddressOf btnClick
            AddHandler btn.KeyDown, AddressOf btnKeyPressed
        Next

        tableBattled.Columns.Add("Pokédex #", GetType(Integer))
        tableBattled.Columns.Add("Pokémon battled", GetType(String))
        tableBattled.Columns.Add("Count", GetType(Integer))

        Me.Select()

        ResumeLayout()
    End Sub

    Private Sub createTable()
        'Data taken from Bulbapedia http://bulbapedia.bulbagarden.net/w/index.php?title=List_of_Pok%C3%A9mon_by_effort_value_yield&oldid=2168747
        tableAllPok.Columns.Add("#", GetType(Integer))
        tableAllPok.Columns.Add("Name", GetType(String))
        tableAllPok.Columns.Add("Exp", GetType(Integer))
        tableAllPok.Columns.Add("HP", GetType(Integer))
        tableAllPok.Columns.Add("Atk", GetType(Integer))
        tableAllPok.Columns.Add("Def", GetType(Integer))
        tableAllPok.Columns.Add("SpAtk", GetType(Integer))
        tableAllPok.Columns.Add("SpDef", GetType(Integer))
        tableAllPok.Columns.Add("Spd", GetType(Integer))
        tableAllPok.Columns.Add("Total", GetType(Integer))

        tableAllPok.Rows.Add(1, "Bulbasaur", 64, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(2, "Ivysaur", 142, 0, 0, 0, 1, 1, 0, 2)
        tableAllPok.Rows.Add(3, "Venusaur", 236, 0, 0, 0, 2, 1, 0, 3)
        tableAllPok.Rows.Add(4, "Charmander", 62, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(5, "Charmeleon", 142, 0, 0, 0, 1, 0, 1, 2)
        tableAllPok.Rows.Add(6, "Charizard", 240, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(7, "Squirtle", 63, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(8, "Wartortle", 142, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(9, "Blastoise", 239, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(10, "Caterpie", 39, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(11, "Metapod", 72, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(12, "Butterfree", 173, 0, 0, 0, 2, 1, 0, 3)
        tableAllPok.Rows.Add(13, "Weedle", 39, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(14, "Kakuna", 72, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(15, "Beedrill", 173, 0, 2, 0, 0, 1, 0, 3)
        tableAllPok.Rows.Add(16, "Pidgey", 50, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(17, "Pidgeotto", 122, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(18, "Pidgeot", 211, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(19, "Rattata", 51, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(20, "Raticate", 145, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(21, "Spearow", 52, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(22, "Fearow", 155, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(23, "Ekans", 58, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(24, "Arbok", 153, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(25, "Pikachu", 105, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(26, "Raichu", 214, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(27, "Sandshrew", 60, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(28, "Sandslash", 158, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(29, "Nidoran♀", 55, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(30, "Nidorina", 128, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(31, "Nidoqueen", 223, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(32, "Nidoran♂", 55, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(33, "Nidorino", 128, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(34, "Nidoking", 223, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(35, "Clefairy", 113, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(36, "Clefable", 213, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(37, "Vulpix", 60, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(38, "Ninetales", 177, 0, 0, 0, 0, 1, 1, 2)
        tableAllPok.Rows.Add(39, "Jigglypuff", 95, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(40, "Wigglytuff", 191, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(41, "Zubat", 49, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(42, "Golbat", 159, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(43, "Oddish", 64, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(44, "Gloom", 138, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(45, "Vileplume", 216, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(46, "Paras", 57, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(47, "Parasect", 142, 0, 2, 1, 0, 0, 0, 3)
        tableAllPok.Rows.Add(48, "Venonat", 61, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(49, "Venomoth", 158, 0, 0, 0, 1, 0, 1, 2)
        tableAllPok.Rows.Add(50, "Diglett", 53, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(51, "Dugtrio", 142, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(52, "Meowth", 58, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(53, "Persian", 154, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(54, "Psyduck", 64, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(55, "Golduck", 175, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(56, "Mankey", 61, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(57, "Primeape", 159, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(58, "Growlithe", 70, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(59, "Arcanine", 194, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(60, "Poliwag", 60, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(61, "Poliwhirl", 135, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(62, "Poliwrath", 225, 0, 0, 3, 0, 0, 0, 3)
        tableAllPok.Rows.Add(63, "Abra", 62, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(64, "Kadabra", 140, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(65, "Alakazam", 221, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(66, "Machop", 61, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(67, "Machoke", 142, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(68, "Machamp", 227, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(69, "Bellsprout", 60, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(70, "Weepinbell", 137, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(71, "Victreebel", 216, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(72, "Tentacool", 67, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(73, "Tentacruel", 180, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(74, "Geodude", 60, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(75, "Graveler", 137, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(76, "Golem", 218, 0, 0, 3, 0, 0, 0, 3)
        tableAllPok.Rows.Add(77, "Ponyta", 82, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(78, "Rapidash", 175, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(79, "Slowpoke", 63, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(80, "Slowbro", 172, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(81, "Magnemite", 65, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(82, "Magneton", 163, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(83, "Farfetch'd", 123, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(84, "Doduo", 62, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(85, "Dodrio", 161, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(86, "Seel", 65, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(87, "Dewgong", 166, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(88, "Grimer", 65, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(89, "Muk", 175, 1, 1, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(90, "Shellder", 61, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(91, "Cloyster", 184, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(92, "Gastly", 62, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(93, "Haunter", 142, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(94, "Gengar", 225, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(95, "Onix", 77, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(96, "Drowzee", 66, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(97, "Hypno", 169, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(98, "Krabby", 65, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(99, "Kingler", 166, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(100, "Voltorb", 66, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(101, "Electrode", 168, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(102, "Exeggcute", 65, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(103, "Exeggutor", 182, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(104, "Cubone", 64, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(105, "Marowak", 149, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(106, "Hitmonlee", 159, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(107, "Hitmonchan", 159, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(108, "Lickitung", 77, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(109, "Koffing", 68, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(110, "Weezing", 172, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(111, "Rhyhorn", 69, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(112, "Rhydon", 170, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(113, "Chansey", 395, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(114, "Tangela", 87, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(115, "Kangaskhan", 172, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(116, "Horsea", 59, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(117, "Seadra", 154, 0, 0, 1, 1, 0, 0, 2)
        tableAllPok.Rows.Add(118, "Goldeen", 64, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(119, "Seaking", 158, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(120, "Staryu", 68, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(121, "Starmie", 182, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(122, "Mr. Mime", 161, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(123, "Scyther", 100, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(124, "Jynx", 159, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(125, "Electabuzz", 172, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(126, "Magmar", 173, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(127, "Pinsir", 175, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(128, "Tauros", 172, 0, 1, 0, 0, 0, 1, 2)
        tableAllPok.Rows.Add(129, "Magikarp", 40, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(130, "Gyarados", 189, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(131, "Lapras", 187, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(132, "Ditto", 101, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(133, "Eevee", 65, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(134, "Vaporeon", 184, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(135, "Jolteon", 184, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(136, "Flareon", 184, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(137, "Porygon", 79, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(138, "Omanyte", 71, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(139, "Omastar", 173, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(140, "Kabuto", 71, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(141, "Kabutops", 173, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(142, "Aerodactyl", 180, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(143, "Snorlax", 189, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(144, "Articuno", 261, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(145, "Zapdos", 261, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(146, "Moltres", 261, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(147, "Dratini", 60, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(148, "Dragonair", 147, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(149, "Dragonite", 270, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(150, "Mewtwo", 306, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(151, "Mew", 270, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(152, "Chikorita", 64, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(153, "Bayleef", 142, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(154, "Meganium", 236, 0, 0, 1, 0, 2, 0, 3)
        tableAllPok.Rows.Add(155, "Cyndaquil", 62, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(156, "Quilava", 142, 0, 0, 0, 1, 0, 1, 2)
        tableAllPok.Rows.Add(157, "Typhlosion", 240, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(158, "Totodile", 63, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(159, "Croconaw", 142, 0, 1, 1, 0, 0, 0, 2)
        tableAllPok.Rows.Add(160, "Feraligatr", 239, 0, 2, 1, 0, 0, 0, 3)
        tableAllPok.Rows.Add(161, "Sentret", 43, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(162, "Furret", 145, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(163, "Hoothoot", 52, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(164, "Noctowl", 155, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(165, "Ledyba", 53, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(166, "Ledian", 137, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(167, "Spinarak", 50, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(168, "Ariados", 137, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(169, "Crobat", 241, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(170, "Chinchou", 66, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(171, "Lanturn", 161, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(172, "Pichu", 41, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(173, "Cleffa", 44, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(174, "Igglybuff", 42, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(175, "Togepi", 49, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(176, "Togetic", 142, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(177, "Natu", 64, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(178, "Xatu", 165, 0, 0, 0, 1, 0, 1, 2)
        tableAllPok.Rows.Add(179, "Mareep", 56, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(180, "Flaaffy", 128, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(181, "Ampharos", 225, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(182, "Bellossom", 216, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(183, "Marill", 88, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(184, "Azumarill", 185, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(185, "Sudowoodo", 144, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(186, "Politoed", 225, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(187, "Hoppip", 50, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(188, "Skiploom", 119, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(189, "Jumpluff", 203, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(190, "Aipom", 72, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(191, "Sunkern", 36, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(192, "Sunflora", 149, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(193, "Yanma", 78, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(194, "Wooper", 42, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(195, "Quagsire", 151, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(196, "Espeon", 184, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(197, "Umbreon", 184, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(198, "Murkrow", 81, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(199, "Slowking", 172, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(200, "Misdreavus", 87, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(201, "Unown", 118, 0, 1, 0, 1, 0, 0, 2)
        tableAllPok.Rows.Add(202, "Wobbuffet", 142, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(203, "Girafarig", 159, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(204, "Pineco", 58, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(205, "Forretress", 163, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(206, "Dunsparce", 145, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(207, "Gligar", 86, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(208, "Steelix", 179, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(209, "Snubbull", 60, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(210, "Granbull", 158, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(211, "Qwilfish", 86, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(212, "Scizor", 175, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(213, "Shuckle", 177, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(214, "Heracross", 175, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(215, "Sneasel", 86, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(216, "Teddiursa", 66, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(217, "Ursaring", 175, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(218, "Slugma", 50, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(219, "Magcargo", 144, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(220, "Swinub", 50, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(221, "Piloswine", 158, 1, 1, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(222, "Corsola", 133, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(223, "Remoraid", 60, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(224, "Octillery", 168, 0, 1, 0, 1, 0, 0, 2)
        tableAllPok.Rows.Add(225, "Delibird", 116, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(226, "Mantine", 163, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(227, "Skarmory", 163, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(228, "Houndour", 66, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(229, "Houndoom", 175, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(230, "Kingdra", 243, 0, 1, 0, 1, 1, 0, 3)
        tableAllPok.Rows.Add(231, "Phanpy", 66, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(232, "Donphan", 175, 0, 1, 1, 0, 0, 0, 2)
        tableAllPok.Rows.Add(233, "Porygon2", 180, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(234, "Stantler", 163, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(235, "Smeargle", 88, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(236, "Tyrogue", 42, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(237, "Hitmontop", 159, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(238, "Smoochum", 61, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(239, "Elekid", 72, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(240, "Magby", 73, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(241, "Miltank", 172, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(242, "Blissey", 608, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(243, "Raikou", 261, 0, 0, 0, 1, 0, 2, 3)
        tableAllPok.Rows.Add(244, "Entei", 261, 1, 2, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(245, "Suicune", 261, 0, 0, 1, 0, 2, 0, 3)
        tableAllPok.Rows.Add(246, "Larvitar", 60, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(247, "Pupitar", 144, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(248, "Tyranitar", 270, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(249, "Lugia", 306, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(250, "Ho-Oh", 306, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(251, "Celebi", 270, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(252, "Treecko", 62, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(253, "Grovyle", 142, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(254, "Sceptile", 239, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(255, "Torchic", 62, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(256, "Combusken", 142, 0, 1, 0, 1, 0, 0, 2)
        tableAllPok.Rows.Add(257, "Blaziken", 239, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(258, "Mudkip", 62, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(259, "Marshtomp", 142, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(260, "Swampert", 241, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(261, "Poochyena", 44, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(262, "Mightyena", 147, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(263, "Zigzagoon", 48, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(264, "Linoone", 147, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(265, "Wurmple", 39, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(266, "Silcoon", 72, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(267, "Beautifly", 173, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(268, "Cascoon", 41, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(269, "Dustox", 135, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(270, "Lotad", 44, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(271, "Lombre", 119, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(272, "Ludicolo", 216, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(273, "Seedot", 44, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(274, "Nuzleaf", 119, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(275, "Shiftry", 216, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(276, "Taillow", 54, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(277, "Swellow", 151, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(278, "Wingull", 54, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(279, "Pelipper", 151, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(280, "Ralts", 40, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(281, "Kirlia", 97, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(282, "Gardevoir", 233, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(283, "Surskit", 54, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(284, "Masquerain", 145, 0, 0, 0, 1, 1, 0, 2)
        tableAllPok.Rows.Add(285, "Shroomish", 59, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(286, "Breloom", 161, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(287, "Slakoth", 56, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(288, "Vigoroth", 154, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(289, "Slaking", 252, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(290, "Nincada", 53, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(291, "Ninjask", 160, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(292, "Shedinja", 83, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(293, "Whismur", 48, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(294, "Loudred", 126, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(295, "Exploud", 216, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(296, "Makuhita", 47, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(297, "Hariyama", 166, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(298, "Azurill", 38, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(299, "Nosepass", 75, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(300, "Skitty", 52, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(301, "Delcatty", 133, 1, 0, 0, 0, 0, 1, 2)
        tableAllPok.Rows.Add(302, "Sableye", 133, 0, 1, 1, 0, 0, 0, 2)
        tableAllPok.Rows.Add(303, "Mawile", 133, 0, 1, 1, 0, 0, 0, 2)
        tableAllPok.Rows.Add(304, "Aron", 66, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(305, "Lairon", 151, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(306, "Aggron", 239, 0, 0, 3, 0, 0, 0, 3)
        tableAllPok.Rows.Add(307, "Meditite", 56, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(308, "Medicham", 144, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(309, "Electrike", 59, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(310, "Manectric", 166, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(311, "Plusle", 142, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(312, "Minun", 142, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(313, "Volbeat", 140, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(314, "Illumise", 140, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(315, "Roselia", 140, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(316, "Gulpin", 60, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(317, "Swalot", 163, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(318, "Carvanha", 61, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(319, "Sharpedo", 161, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(320, "Wailmer", 80, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(321, "Wailord", 175, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(322, "Numel", 61, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(323, "Camerupt", 161, 0, 1, 0, 1, 0, 0, 2)
        tableAllPok.Rows.Add(324, "Torkoal", 165, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(325, "Spoink", 66, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(326, "Grumpig", 165, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(327, "Spinda", 126, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(328, "Trapinch", 58, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(329, "Vibrava", 119, 0, 1, 0, 0, 0, 1, 2)
        tableAllPok.Rows.Add(330, "Flygon", 234, 0, 1, 0, 0, 0, 2, 3)
        tableAllPok.Rows.Add(331, "Cacnea", 67, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(332, "Cacturne", 166, 0, 1, 0, 1, 0, 0, 2)
        tableAllPok.Rows.Add(333, "Swablu", 62, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(334, "Altaria", 172, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(335, "Zangoose", 160, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(336, "Seviper", 160, 0, 1, 0, 1, 0, 0, 2)
        tableAllPok.Rows.Add(337, "Lunatone", 154, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(338, "Solrock", 154, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(339, "Barboach", 58, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(340, "Whiscash", 164, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(341, "Corphish", 62, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(342, "Crawdaunt", 164, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(343, "Baltoy", 60, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(344, "Claydol", 175, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(345, "Lileep", 71, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(346, "Cradily", 173, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(347, "Anorith", 71, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(348, "Armaldo", 173, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(349, "Feebas", 40, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(350, "Milotic", 189, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(351, "Castform", 147, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(352, "Kecleon", 154, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(353, "Shuppet", 59, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(354, "Banette", 159, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(355, "Duskull", 59, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(356, "Dusclops", 159, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(357, "Tropius", 161, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(358, "Chimecho", 149, 0, 0, 0, 1, 1, 0, 2)
        tableAllPok.Rows.Add(359, "Absol", 163, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(360, "Wynaut", 52, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(361, "Snorunt", 60, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(362, "Glalie", 168, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(363, "Spheal", 58, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(364, "Sealeo", 144, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(365, "Walrein", 239, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(366, "Clamperl", 69, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(367, "Huntail", 170, 0, 1, 1, 0, 0, 0, 2)
        tableAllPok.Rows.Add(368, "Gorebyss", 170, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(369, "Relicanth", 170, 1, 0, 1, 0, 0, 0, 2)
        tableAllPok.Rows.Add(370, "Luvdisc", 116, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(371, "Bagon", 60, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(372, "Shelgon", 147, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(373, "Salamence", 270, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(374, "Beldum", 60, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(375, "Metang", 147, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(376, "Metagross", 270, 0, 0, 3, 0, 0, 0, 3)
        tableAllPok.Rows.Add(377, "Regirock", 261, 0, 0, 3, 0, 0, 0, 3)
        tableAllPok.Rows.Add(378, "Regice", 261, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(379, "Registeel", 261, 0, 0, 2, 0, 1, 0, 3)
        tableAllPok.Rows.Add(380, "Latias", 270, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(381, "Latios", 270, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(382, "Kyogre", 302, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(383, "Groudon", 302, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(384, "Rayquaza", 306, 0, 2, 0, 1, 0, 0, 3)
        tableAllPok.Rows.Add(385, "Jirachi", 270, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(386, "Deoxys (Normal Forme)", 270, 0, 1, 0, 1, 0, 1, 3)
        tableAllPok.Rows.Add(386, "Deoxys (Attack Forme)", 270, 0, 2, 0, 1, 0, 0, 3)
        tableAllPok.Rows.Add(386, "Deoxys (Defense Forme)", 270, 0, 0, 2, 0, 1, 0, 3)
        tableAllPok.Rows.Add(386, "Deoxys (Speed Forme)", 270, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(387, "Turtwig", 64, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(388, "Grotle", 142, 0, 1, 1, 0, 0, 0, 2)
        tableAllPok.Rows.Add(389, "Torterra", 236, 0, 2, 1, 0, 0, 0, 3)
        tableAllPok.Rows.Add(390, "Chimchar", 62, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(391, "Monferno", 142, 0, 0, 0, 1, 0, 1, 2)
        tableAllPok.Rows.Add(392, "Infernape", 240, 0, 1, 0, 1, 0, 1, 3)
        tableAllPok.Rows.Add(393, "Piplup", 63, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(394, "Prinplup", 142, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(395, "Empoleon", 239, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(396, "Starly", 49, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(397, "Staravia", 119, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(398, "Staraptor", 214, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(399, "Bidoof", 50, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(400, "Bibarel", 144, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(401, "Kricketot", 39, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(402, "Kricketune", 134, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(403, "Shinx", 53, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(404, "Luxio", 127, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(405, "Luxray", 235, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(406, "Budew", 56, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(407, "Roserade", 227, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(408, "Cranidos", 70, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(409, "Rampardos", 173, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(410, "Shieldon", 70, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(411, "Bastiodon", 173, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(412, "Burmy", 45, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(413, "Wormadam (Plant Cloak)", 148, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(413, "Wormadam (Sandy Cloak)", 148, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(413, "Wormadam (Trash Cloak)", 148, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(414, "Mothim", 148, 0, 1, 0, 1, 0, 0, 2)
        tableAllPok.Rows.Add(415, "Combee", 49, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(416, "Vespiquen", 166, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(417, "Pachirisu", 142, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(418, "Buizel", 66, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(419, "Floatzel", 173, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(420, "Cherubi", 55, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(421, "Cherrim", 158, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(422, "Shellos", 65, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(423, "Gastrodon", 166, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(424, "Ambipom", 169, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(425, "Drifloon", 70, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(426, "Drifblim", 174, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(427, "Buneary", 70, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(428, "Lopunny", 168, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(429, "Mismagius", 173, 0, 0, 0, 1, 1, 0, 2)
        tableAllPok.Rows.Add(430, "Honchkrow", 177, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(431, "Glameow", 62, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(432, "Purugly", 158, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(433, "Chingling", 57, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(434, "Stunky", 66, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(435, "Skuntank", 168, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(436, "Bronzor", 60, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(437, "Bronzong", 175, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(438, "Bonsly", 58, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(439, "Mime Jr.", 62, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(440, "Happiny", 110, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(441, "Chatot", 144, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(442, "Spiritomb", 170, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(443, "Gible", 60, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(444, "Gabite", 144, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(445, "Garchomp", 270, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(446, "Munchlax", 78, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(447, "Riolu", 57, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(448, "Lucario", 184, 0, 1, 0, 1, 0, 0, 2)
        tableAllPok.Rows.Add(449, "Hippopotas", 66, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(450, "Hippowdon", 184, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(451, "Skorupi", 66, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(452, "Drapion", 175, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(453, "Croagunk", 60, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(454, "Toxicroak", 172, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(455, "Carnivine", 159, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(456, "Finneon", 66, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(457, "Lumineon", 161, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(458, "Mantyke", 69, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(459, "Snover", 67, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(460, "Abomasnow", 173, 0, 1, 0, 1, 0, 0, 2)
        tableAllPok.Rows.Add(461, "Weavile", 179, 0, 1, 0, 0, 0, 1, 2)
        tableAllPok.Rows.Add(462, "Magnezone", 241, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(463, "Lickilicky", 180, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(464, "Rhyperior", 241, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(465, "Tangrowth", 187, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(466, "Electivire", 243, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(467, "Magmortar", 243, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(468, "Togekiss", 245, 0, 0, 0, 2, 1, 0, 3)
        tableAllPok.Rows.Add(469, "Yanmega", 180, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(470, "Leafeon", 184, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(471, "Glaceon", 184, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(472, "Gliscor", 179, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(473, "Mamoswine", 239, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(474, "Porygon-Z", 241, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(475, "Gallade", 233, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(476, "Probopass", 184, 0, 0, 1, 0, 2, 0, 3)
        tableAllPok.Rows.Add(477, "Dusknoir", 236, 0, 0, 1, 0, 2, 0, 3)
        tableAllPok.Rows.Add(478, "Froslass", 168, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(479, "Rotom", 154, 0, 0, 0, 1, 0, 1, 2)
        tableAllPok.Rows.Add(480, "Uxie", 261, 0, 0, 2, 0, 1, 0, 3)
        tableAllPok.Rows.Add(481, "Mesprit", 261, 0, 1, 0, 1, 1, 0, 3)
        tableAllPok.Rows.Add(482, "Azelf", 261, 0, 2, 0, 1, 0, 0, 3)
        tableAllPok.Rows.Add(483, "Dialga", 306, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(484, "Palkia", 306, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(485, "Heatran", 270, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(486, "Regigigas", 302, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(487, "Giratina", 306, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(488, "Cresselia", 270, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(489, "Phione", 216, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(490, "Manaphy", 270, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(491, "Darkrai", 270, 0, 0, 0, 2, 0, 1, 3)
        tableAllPok.Rows.Add(492, "Shaymin (Land Forme)", 270, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(492, "Shaymin (Sky Forme)", 270, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(493, "Arceus", 324, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(494, "Victini", 270, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(495, "Snivy", 28, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(496, "Servine", 145, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(497, "Serperior", 238, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(498, "Tepig", 28, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(499, "Pignite", 146, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(500, "Emboar", 238, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(501, "Oshawott", 28, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(502, "Dewott", 145, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(503, "Samurott", 238, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(504, "Patrat", 51, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(505, "Watchog", 147, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(506, "Lillipup", 55, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(507, "Herdier", 130, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(508, "Stoutland", 221, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(509, "Purrloin", 56, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(510, "Liepard", 156, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(511, "Pansage", 63, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(512, "Simisage", 174, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(513, "Pansear", 63, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(514, "Simisear", 174, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(515, "Panpour", 63, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(516, "Simipour", 174, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(517, "Munna", 58, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(518, "Musharna", 170, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(519, "Pidove", 53, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(520, "Tranquill", 125, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(521, "Unfezant", 215, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(522, "Blitzle", 59, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(523, "Zebstrika", 174, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(524, "Roggenrola", 56, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(525, "Boldore", 137, 0, 1, 1, 0, 0, 0, 2)
        tableAllPok.Rows.Add(526, "Gigalith", 227, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(527, "Woobat", 63, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(528, "Swoobat", 149, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(529, "Drilbur", 66, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(530, "Excadrill", 178, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(531, "Audino", 390, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(532, "Timburr", 61, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(533, "Gurdurr", 142, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(534, "Conkeldurr", 227, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(535, "Tympole", 59, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(536, "Palpitoad", 134, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(537, "Seismitoad", 225, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(538, "Throh", 163, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(539, "Sawk", 163, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(540, "Sewaddle", 62, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(541, "Swadloon", 133, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(542, "Leavanny", 221, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(543, "Venipede", 52, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(544, "Whirlipede", 126, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(545, "Scolipede", 214, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(546, "Cottonee", 56, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(547, "Whimsicott", 168, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(548, "Petilil", 56, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(549, "Lilligant", 168, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(550, "Basculin", 161, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(551, "Sandile", 58, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(552, "Krokorok", 123, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(553, "Krookodile", 229, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(554, "Darumaka", 63, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(555, "Darmanitan (Standard Mode)", 168, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(555, "Darmanitan (Zen Mode)", 168, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(556, "Maractus", 161, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(557, "Dwebble", 65, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(558, "Crustle", 166, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(559, "Scraggy", 70, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(560, "Scrafty", 171, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(561, "Sigilyph", 172, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(562, "Yamask", 61, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(563, "Cofagrigus", 169, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(564, "Tirtouga", 71, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(565, "Carracosta", 173, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(566, "Archen", 71, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(567, "Archeops", 177, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(568, "Trubbish", 66, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(569, "Garbodor", 166, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(570, "Zorua", 66, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(571, "Zoroark", 179, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(572, "Minccino", 60, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(573, "Cinccino", 165, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(574, "Gothita", 58, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(575, "Gothorita", 137, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(576, "Gothitelle", 221, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(577, "Solosis", 58, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(578, "Duosion", 130, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(579, "Reuniclus", 221, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(580, "Ducklett", 61, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(581, "Swanna", 166, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(582, "Vanillite", 61, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(583, "Vanillish", 138, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(584, "Vanilluxe", 241, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(585, "Deerling", 67, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(586, "Sawsbuck", 166, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(587, "Emolga", 150, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(588, "Karrablast", 63, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(589, "Escavalier", 173, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(590, "Foongus", 59, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(591, "Amoonguss", 162, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(592, "Frillish", 67, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(593, "Jellicent", 168, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(594, "Alomomola", 165, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(595, "Joltik", 64, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(596, "Galvantula", 165, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(597, "Ferroseed", 61, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(598, "Ferrothorn", 171, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(599, "Klink", 60, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(600, "Klang", 154, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(601, "Klinklang", 234, 0, 0, 3, 0, 0, 0, 3)
        tableAllPok.Rows.Add(602, "Tynamo", 55, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(603, "Eelektrik", 142, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(604, "Eelektross", 232, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(605, "Elgyem", 67, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(606, "Beheeyem", 170, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(607, "Litwick", 55, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(608, "Lampent", 130, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(609, "Chandelure", 234, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(610, "Axew", 64, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(611, "Fraxure", 144, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(612, "Haxorus", 243, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(613, "Cubchoo", 61, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(614, "Beartic", 170, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(615, "Cryogonal", 170, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(616, "Shelmet", 61, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(617, "Accelgor", 173, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(618, "Stunfisk", 165, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(619, "Mienfoo", 70, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(620, "Mienshao", 179, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(621, "Druddigon", 170, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(622, "Golett", 61, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(623, "Golurk", 169, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(624, "Pawniard", 68, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(625, "Bisharp", 172, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(626, "Bouffalant", 172, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(627, "Rufflet", 70, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(628, "Braviary", 179, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(629, "Vullaby", 74, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(630, "Mandibuzz", 179, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(631, "Heatmor", 169, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(632, "Durant", 169, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(633, "Deino", 60, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(634, "Zweilous", 147, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(635, "Hydreigon", 270, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(636, "Larvesta", 72, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(637, "Volcarona", 248, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(638, "Cobalion", 261, 0, 0, 3, 0, 0, 0, 3)
        tableAllPok.Rows.Add(639, "Terrakion", 261, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(640, "Virizion", 261, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(641, "Tornadus (Incarnate Forme)", 261, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(641, "Tornadus (Therian Forme)", 261, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(642, "Thundurus (Incarnate Forme)", 261, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(642, "Thundurus (Therian Forme)", 261, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(643, "Reshiram", 306, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(644, "Zekrom", 306, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(645, "Landorus (Incarnate Forme)", 270, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(645, "Landorus (Therian Forme)", 270, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(646, "Kyurem", 297, 1, 1, 0, 1, 0, 0, 3)
        tableAllPok.Rows.Add(646, "Kyurem (Black Kyurem)", 297, 0, 3, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(646, "Kyurem (White Kyurem)", 297, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(647, "Keldeo", 261, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(648, "Meloetta (Aria Forme)", 270, 0, 0, 0, 1, 1, 1, 3)
        tableAllPok.Rows.Add(648, "Meloetta (Pirouette Forme)", 270, 0, 1, 1, 0, 0, 1, 3)
        tableAllPok.Rows.Add(649, "Genesect", 270, 0, 1, 0, 1, 0, 1, 3)
        tableAllPok.Rows.Add(650, "Chespin", 63, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(651, "Quilladin", 142, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(652, "Chesnaught", 239, 0, 0, 3, 0, 0, 0, 3)
        tableAllPok.Rows.Add(653, "Fennekin", 61, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(654, "Braixen", 143, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(655, "Delphox", 240, 0, 0, 0, 3, 0, 0, 3)
        tableAllPok.Rows.Add(656, "Froakie", 63, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(657, "Frogadier", 142, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(658, "Greninja", 239, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(659, "Bunnelby", 47, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(660, "Diggersby", 148, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(661, "Fletchling", 56, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(662, "Fletchinder", 134, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(663, "Talonflame", 175, 0, 0, 0, 0, 0, 3, 3)
        tableAllPok.Rows.Add(664, "Scatterbug", 40, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(665, "Spewpa", 75, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(666, "Vivillon", 185, 1, 0, 0, 1, 0, 1, 3)
        tableAllPok.Rows.Add(667, "Litleo", 74, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(668, "Pyroar", 177, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(669, "Flabébé", 61, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(670, "Floette", 130, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(671, "Florges", 248, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(672, "Skiddo", 70, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(673, "Gogoat", 186, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(674, "Pancham", 70, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(675, "Pangoro", 173, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(676, "Furfrou", 165, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(677, "Espurr", 71, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(678, "Meowstic", 163, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(679, "Honedge", 65, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(680, "Doublade", 157, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(681, "Aegislash", 234, 0, 0, 2, 0, 1, 0, 3)
        tableAllPok.Rows.Add(682, "Spritzee", 68, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(683, "Aromatisse", 162, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(684, "Swirlix", 68, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(685, "Slurpuff", 168, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(686, "Inkay", 58, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(687, "Malamar", 169, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(688, "Binacle", 61, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(689, "Barbaracle", 175, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(690, "Skrelp", 64, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(691, "Dragalge", 173, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(692, "Clauncher", 66, 0, 0, 0, 1, 0, 0, 1)
        tableAllPok.Rows.Add(693, "Clawitzer", 100, 0, 0, 0, 2, 0, 0, 2)
        tableAllPok.Rows.Add(694, "Helioptile", 58, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(695, "Heliolisk", 168, 0, 0, 0, 1, 0, 1, 2)
        tableAllPok.Rows.Add(696, "Tyrunt", 72, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(697, "Tyrantrum", 182, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(698, "Amaura", 72, 1, 0, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(699, "Aurorus", 104, 2, 0, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(700, "Sylveon", 184, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(701, "Hawlucha", 175, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(702, "Dedenne", 151, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(703, "Carbink", 100, 0, 0, 1, 0, 1, 0, 2)
        tableAllPok.Rows.Add(704, "Goomy", 60, 0, 0, 0, 0, 1, 0, 1)
        tableAllPok.Rows.Add(705, "Sliggoo", 158, 0, 0, 0, 0, 2, 0, 2)
        tableAllPok.Rows.Add(706, "Goodra", 270, 0, 0, 0, 0, 3, 0, 3)
        tableAllPok.Rows.Add(707, "Klefki", 165, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(708, "Phantump", 62, 0, 1, 0, 0, 0, 0, 1)
        tableAllPok.Rows.Add(709, "Trevenant", 166, 0, 2, 0, 0, 0, 0, 2)
        tableAllPok.Rows.Add(710, "Pumpkaboo", 67, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(711, "Gourgeist", 173, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(712, "Bergmite", 61, 0, 0, 1, 0, 0, 0, 1)
        tableAllPok.Rows.Add(713, "Avalugg", 180, 0, 0, 2, 0, 0, 0, 2)
        tableAllPok.Rows.Add(714, "Noibat", 49, 0, 0, 0, 0, 0, 1, 1)
        tableAllPok.Rows.Add(715, "Noivern", 187, 0, 0, 0, 0, 0, 2, 2)
        tableAllPok.Rows.Add(716, "Xerneas", 306, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(717, "Yveltal", 306, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(718, "Zygarde", 270, 3, 0, 0, 0, 0, 0, 3)
        tableAllPok.Rows.Add(719, "Diancie", 270, 0, 0, 1, 0, 2, 0, 3)

    End Sub

    Private Sub PokédexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PokédexToolStripMenuItem.Click 'Sort list by Pokédex entry
        battlePokemonList("dex")
    End Sub

    Private Sub NameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NameToolStripMenuItem.Click 'Sort list by Pokédex entry
        battlePokemonList("name")
    End Sub

    Private Sub battlePokemonList(ByVal type As String)
        cmb_enemy.Items.Clear()

        Dim values

        If type = "name" Then
            values = tableAllPok.AsEnumerable().OrderBy(Function(row) row.Field(Of String)("Name")).Select(Function(row) row.Field(Of String)("Name")).ToArray()
        Else
            values = tableAllPok.AsEnumerable().OrderBy(Function(row) row.Field(Of Integer)("#")).Select(Function(row) row.Field(Of String)("Name")).ToArray()
        End If

        cmb_enemy.Items.AddRange(values)
        cmb_enemy.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub cmb_enemy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_enemy.SelectedIndexChanged
        Dim selected As String = cmb_enemy.Text

        SuspendLayout()

        If selected = "" Then
            lb_EnemyHP.Text = ""
            lb_EnemyAtk.Text = ""
            lb_EnemyDef.Text = ""
            lb_EnemySpAtk.Text = ""
            lb_EnemySpDef.Text = ""
            lb_EnemySpd.Text = ""

            ResumeLayout()
            Exit Sub
        End If

        For Each i As DataRow In tableAllPok.AsEnumerable()

            If i(1) = selected Then
                lb_EnemyHP.Text = i(3)
                lb_EnemyAtk.Text = i(4)
                lb_EnemyDef.Text = i(5)
                lb_EnemySpAtk.Text = i(6)
                lb_EnemySpDef.Text = i(7)
                lb_EnemySpd.Text = i(8)

                Exit For
            End If
        Next

        ResumeLayout()
    End Sub

    Private Sub btnClick(sender As Object, e As MouseEventArgs)
        Dim count As Integer = Strings.Right(sender.name.ToString, 1)
        Dim mode As String = Nothing

        If e.Button = Windows.Forms.MouseButtons.Left Then
            mode = "add"
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            mode = "subtract"
        Else
            Exit Sub
        End If

        train(count, mode, cmb_enemy.Text)
    End Sub

    Private Sub btnKeyPressed(sender As Object, e As KeyEventArgs)
        Dim count As Integer = Strings.Right(sender.name.ToString, 1)
        Dim mode As String

        If e.KeyCode = Windows.Forms.Keys.Space OrElse e.KeyCode = Windows.Forms.Keys.Return OrElse e.KeyCode = Windows.Forms.Keys.Enter Then
            mode = "add"
        Else
            Exit Sub
        End If

        train(count, mode, cmb_enemy.Text)
    End Sub

    Private Sub train(enemyCount As Integer, action As String, enemy As String)
        If checkValidAll(True) = False Then
            Exit Sub
        End If

        SuspendLayout()

        If action = "add" Then
            tb_CurrentHP.Text = Val(tb_CurrentHP.Text) + CInt(lb_EnemyHP.Text) * enemyCount
            tb_CurrentAtk.Text = Val(tb_CurrentAtk.Text) + CInt(lb_EnemyAtk.Text) * enemyCount
            tb_CurrentDef.Text = Val(tb_CurrentDef.Text) + CInt(lb_EnemyDef.Text) * enemyCount
            tb_CurrentSpAtk.Text = Val(tb_CurrentSpAtk.Text) + CInt(lb_EnemySpAtk.Text) * enemyCount
            tb_CurrentSpDef.Text = Val(tb_CurrentSpDef.Text) + CInt(lb_EnemySpDef.Text) * enemyCount
            tb_CurrentSpd.Text = Val(tb_CurrentSpd.Text) + CInt(lb_EnemySpd.Text) * enemyCount
        ElseIf action = "subtract" Then
            tb_CurrentHP.Text = Val(tb_CurrentHP.Text) - CInt(lb_EnemyHP.Text) * enemyCount
            tb_CurrentAtk.Text = Val(tb_CurrentAtk.Text) - CInt(lb_EnemyAtk.Text) * enemyCount
            tb_CurrentDef.Text = Val(tb_CurrentDef.Text) - CInt(lb_EnemyDef.Text) * enemyCount
            tb_CurrentSpAtk.Text = Val(tb_CurrentSpAtk.Text) - CInt(lb_EnemySpAtk.Text) * enemyCount
            tb_CurrentSpDef.Text = Val(tb_CurrentSpDef.Text) - CInt(lb_EnemySpDef.Text) * enemyCount
            tb_CurrentSpd.Text = Val(tb_CurrentSpd.Text) - CInt(lb_EnemySpd.Text) * enemyCount
        End If

        enemyHistoryEdit(action, enemy, enemyCount)

        For Each tb In gb_TrainingPok.Controls.OfType(Of TextBox)()
            If InStr(tb.Name.ToString, "tb_Current") <> 0 Then
                If Val(tb.Text) = 0 Then
                    tb.Text = ""
                End If
            End If
        Next

        statsUpdated()

        If chk_clear.Checked = True Then
            cmb_enemy.SelectedIndex = -1
        End If
        ResumeLayout()
    End Sub

    Private Sub statsUpdated()
        SuspendLayout()

        lb_TotalPlanned.Text = Val(tb_PlannedHP.Text) + Val(tb_PlannedAtk.Text) + Val(tb_PlannedDef.Text) + Val(tb_PlannedSpAtk.Text) + Val(tb_PlannedSpDef.Text) + Val(tb_PlannedSpd.Text)
        lb_TotalCurrent.Text = Val(tb_CurrentHP.Text) + Val(tb_CurrentAtk.Text) + Val(tb_CurrentDef.Text) + Val(tb_CurrentSpAtk.Text) + Val(tb_CurrentSpDef.Text) + Val(tb_CurrentSpd.Text)

        If Val(lb_TotalPlanned.Text) > 510 Then
            lb_TotalPlanned.ForeColor = Color.DarkRed
        Else
            lb_TotalPlanned.ForeColor = SystemColors.ControlText
        End If

        If Val(lb_TotalCurrent.Text) > 510 Then
            lb_TotalCurrent.ForeColor = Color.DarkRed
        Else
            lb_TotalCurrent.ForeColor = SystemColors.ControlText
        End If

        ResumeLayout()
    End Sub

    Private Sub seeMax(stat As Control)
        If rd_255.Checked = False AndAlso rd_252.Checked = False Then
            MsgBox("Please select the maximum number of EVs per stat.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Incomplete data")
            Exit Sub
        End If

        Dim max As Integer
        If rd_255.Checked = True Then
            max = 255
        Else
            max = 252
        End If

        If Val(stat.Text) > max Then
            stat.ForeColor = Color.DarkRed
        Else
            stat.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub tbTextChanged(sender As Object, e As EventArgs)
        Dim tb = DirectCast(sender, TextBox)
        seeMax(tb)
        statsUpdated()
        isDirty = True
    End Sub

    Private Sub rd_255_CheckedChanged(sender As Object, e As EventArgs) Handles rd_255.CheckedChanged
        seeMax(tb_PlannedHP)
        seeMax(tb_PlannedAtk)
        seeMax(tb_PlannedDef)
        seeMax(tb_PlannedSpAtk)
        seeMax(tb_PlannedSpDef)
        seeMax(tb_PlannedSpd)

        isDirty = True
    End Sub

    Private Sub rd_252_CheckedChanged(sender As Object, e As EventArgs) Handles rd_252.CheckedChanged
        seeMax(tb_PlannedHP)
        seeMax(tb_PlannedAtk)
        seeMax(tb_PlannedDef)
        seeMax(tb_PlannedSpAtk)
        seeMax(tb_PlannedSpDef)
        seeMax(tb_PlannedSpd)

        isDirty = True
    End Sub

    Private Sub form_main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If newHasBeenAdded = True AndAlso isDirty = False Then
            saveData.delete(cmb_SelectedPok.Text)
            Exit Sub
        End If

        If isDirty = True Then
            testAndSave(cmb_SelectedPok.Text, False, True)
            If saveWasCancelled = True Then
                Exit Sub
            End If
        End If
    End Sub

    Private Function checkValidAll(Optional ByVal battleAsWell As Boolean = True) As Boolean
        If cmb_SelectedPok.Text = "" Then
            MsgBox("Please select the Pokémon that you are training.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Incomplete data")
            Return False
        End If

        If rd_255.Checked = False AndAlso rd_252.Checked = False Then
            MsgBox("Please select the maximum number of EVs per stat.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Incomplete data")
            Return False
        End If

        If battleAsWell = True Then
            If cmb_enemy.Text = "" Then
                MsgBox("Please select the Pokémon that you are battling against.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Incomplete data")
                Return False
            End If

            Dim isRealPok As Boolean = False
            For Each i As String In tableAllPok.AsEnumerable().Select(Function(row) row.Field(Of String)("Name"))
                If cmb_enemy.Text = i Then
                    isRealPok = True
                    Exit For
                End If
            Next
            If isRealPok = False Then
                MsgBox("Please select a real Pokémon that you are battling against.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Incomplete data")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SAVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SAVEToolStripMenuItem.Click
        testAndSave(cmb_SelectedPok.Text, False, False)
    End Sub

    Private Sub DELETESAVEFILEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DELETESAVEFILEToolStripMenuItem.Click
        If MsgBox("Are you sure you want to delete the save file for " & cmb_SelectedPok.Text & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation Or MsgBoxStyle.ApplicationModal, "Sure to delte?") = vbYes Then
            saveData.delete(cmb_SelectedPok.Text)
        End If

    End Sub

    Public Sub cmb_SelectedPok_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_SelectedPok.SelectedIndexChanged
        SuspendLayout()
        If cmb_SelectedPok.Text = "" Then
            clearForm()
            SAVEToolStripMenuItem.Enabled = False
            DELETESAVEFILEToolStripMenuItem.Enabled = False

            ResumeLayout()
            Exit Sub
        Else
            SAVEToolStripMenuItem.Enabled = True
            DELETESAVEFILEToolStripMenuItem.Enabled = True
            gb_TrainingPok.Enabled = True
            gb_enemy.Enabled = True
        End If
        ResumeLayout()

        Dim reselect As String = cmb_SelectedPok.Text

        If newHasBeenAdded = True AndAlso isDirty = False Then
            SuspendLayout()

            newHasBeenAdded = False
            saveData.delete(previousPok)

            cmb_SelectedPok.SelectedItem = reselect

            ResumeLayout()
            Exit Sub
        End If

        If isDirty = True Then
            testAndSave(previousPok, False, True)
            If saveWasCancelled = True Then
                Exit Sub
            End If
        End If

        tableBattled.Clear()
        saveData.loadStats(reselect)

        Me.Select() 'remove focus from the combobox, so that values can be saved when changing the index again

        isDirty = False
        newHasBeenAdded = False
    End Sub

    Private Sub testAndSave(pokToCheck As String, shouldCheckBattleAsWell As Boolean, shouldAskToSave As Boolean)
        saveWasCancelled = False

        If checkValidAll(shouldCheckBattleAsWell) = False Then
            Exit Sub
        End If

        'Dim currentPok As String = cmb_SelectedPok.Text

        Dim askResult As MsgBoxResult
        If shouldAskToSave = True Then
            askResult = saveData.askSave(pokToCheck)
        Else
            askResult = vbYes
        End If

        If askResult = vbCancel Then
            RemoveHandler cmb_SelectedPok.SelectedIndexChanged, AddressOf cmb_SelectedPok_SelectedIndexChanged
            cmb_SelectedPok.SelectedItem = previousPok
            AddHandler cmb_SelectedPok.SelectedIndexChanged, AddressOf cmb_SelectedPok_SelectedIndexChanged

            saveWasCancelled = True

            Exit Sub
        End If

        If newHasBeenAdded = True AndAlso askResult = vbNo Then
            saveData.delete(pokToCheck, False)

            newHasBeenAdded = False
        End If

        If pokToCheck <> Nothing AndAlso askResult = vbYes Then
            saveData.savePok(pokToCheck)
            isDirty = False
        End If
    End Sub

    Private Sub cmb_SelectedPok_Enter(sender As Object, e As EventArgs) Handles cmb_SelectedPok.Enter
        previousPok = cmb_SelectedPok.Text

        'If cmb_SelectedPok.Items.Count = 0 Then
        '    cmb_SelectedPok.Items.Add(InputBox("No Pokémon being trained has been added yet." & vbNewLine & vbNewLine & "Please enter the name of your first Pokémon.", "Enter Pokémon name"))
        'End If

        'saveData.trainPokemonList()
    End Sub

    Private Sub btn_addNewPok_Click(sender As Object, e As EventArgs) Handles btn_addNewPok.Click
        newPok()
    End Sub

    Private Sub clearForm()
        forceClearRadios()

        For Each tb In gb_TrainingPok.Controls.OfType(Of TextBox)()
            RemoveHandler tb.TextChanged, AddressOf tbTextChanged

            tb.Text = ""

            AddHandler tb.TextChanged, AddressOf tbTextChanged
        Next

        lb_TotalPlanned.Text = ""
        lb_TotalCurrent.Text = ""

        tableBattled.Clear()

        gb_TrainingPok.Enabled = False
        gb_enemy.Enabled = False
    End Sub

    Private Sub forceClearRadios()
        RemoveHandler rd_255.CheckedChanged, AddressOf rd_255_CheckedChanged
        RemoveHandler rd_252.CheckedChanged, AddressOf rd_252_CheckedChanged
        rd_255.Checked = False
        rd_252.Checked = False
        AddHandler rd_255.CheckedChanged, AddressOf rd_255_CheckedChanged
        AddHandler rd_252.CheckedChanged, AddressOf rd_252_CheckedChanged
    End Sub

    Private Sub NEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NEWToolStripMenuItem.Click
        newPok()
    End Sub

    Private Sub newPok()
        Dim newPok As String = Nothing
        Dim hasFailed As Boolean = True

        Do While hasFailed = True
            newPok = InputBox("Please enter the name of the Pokémon being trained.", "Enter Pokémon name")

            If validateName(newPok) = False Then
                Dim msg As String = "An invalid name has been entered." & vbNewLine & vbNewLine & "Please do not use any of the following characters:"
                Dim invalidString As String = "# % & { } \ / < > * ? $ ! ‘ ' "" : @ + ` | ="
                MsgBox(msg & vbNewLine & invalidString, vbOKOnly Or vbCritical, "Invalid Pokémon name")

                hasFailed = True
            ElseIf cmb_SelectedPok.Items.Contains(newPok) = True Then
                MsgBox("Please enter a name that is not already in the list.", vbOKOnly Or vbCritical, "Duplicate entries")
                hasFailed = True
            ElseIf newPok = "" Then 'cancelled or typed ""
                Exit Sub
            Else
                hasFailed = False
            End If
        Loop

        SuspendLayout()

        clearForm()
        saveData.savePok(newPok)

        trainPokemonList()
        cmb_SelectedPok.SelectedItem = newPok

        forceClearRadios()

        ResumeLayout()

        isDirty = False
        newHasBeenAdded = True
    End Sub

    Private Function validateName(name As String)
        Dim invalidCharacters() As Char = {"#", "%", "&", "{", "}", "\", "<", ">", "*", "?", "/", " ", "$", "!", "‘", "'", """,""", ":", "@", "+", "`", "|", "="}

        For Each symbol As Char In invalidCharacters
            If InStr(name, symbol) <> 0 Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub btn_enemyHistory_Click(sender As Object, e As EventArgs) Handles btn_enemyHistory.Click
        'show the history
        form_battleHistory.Show()
    End Sub

    Private Sub enemyHistoryEdit(ByVal action As String, pok As String, enemyCount As Integer)
        Dim netEffect As Integer = enemyCount * If(action = "add", 1, -1)

        Dim isAlreadyInTable As Boolean = False
        Dim battleTableIndex As Integer = -1

        For Each r In tableBattled.Rows()
            battleTableIndex += 1

            If pok = r(1) Then
                isAlreadyInTable = True
                Exit For
            End If
        Next

        If isAlreadyInTable = False Then
            tableBattled.Rows.Add(getDexNo(pok), pok, netEffect)

        ElseIf isAlreadyInTable = True Then
            tableBattled.Rows(battleTableIndex).Item(2) += netEffect

            'remove zero entries:
            If tableBattled.Rows(battleTableIndex).Item(2) = 0 Then
                tableBattled.Rows(battleTableIndex).Delete()
            End If
        End If

        tableBattled.DefaultView.Sort = "Pokémon battled ASC"
    End Sub

    Private Function getDexNo(pok As String) As Integer
        Dim mainTableIndex As Integer = -1

        For Each r In tableAllPok.Rows
            mainTableIndex += 1

            If pok = r(1) Then
                Exit For
            End If
        Next

        Return tableAllPok.Rows(mainTableIndex)(0)
    End Function

    Private Sub EXITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXITToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ABOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABOUTToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub
End Class
