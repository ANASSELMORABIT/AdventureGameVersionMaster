public static class ReglasJuegoMenu
{
    public static void AboutGame()
{
    string titulo = "📜 Game Rules 📜";
    string[] reglas = {
        "1. 🎲 The player starts by rolling two 6-sided dice to determine the damage dealt to the enemy.",
        "2. 🏹 The player's attack level is determined by the dice roll, plus skill points multiplied by 0.10.",
        "3. 💡 Skill points add to the dice roll result, making the player stronger as they accumulate more skill points.",
        "4. 🏆 For each enemy defeated, the player levels up and becomes stronger, preparing for tougher challenges.",
        "5. 💪 If the player has a higher level than the enemy, they win the battle automatically without needing to roll the dice.",
        "6. 🗺️ The game consists of three maps with the following structure:",
        "   - First Map: Fight against 6 basic enemies.",
        "   - Second Map: Battle 5 special enemies that are tougher and require strategy.",
        "   - Final Map: Defeat the Boss in the last map to complete the adventure.",
        "7. ⚡ If the player passes 3 rounds (one round for each map) without losing, they gain the ability to choose one of the 3 special characters: Wizard, Archer, or Warrior.",
        "8. 🎯 Defeating all enemies in each map, including the Boss in the final round, is the objective to complete the game."
    };

    DecoracionUtils.MostrarConBordes(titulo, reglas);
}

   public static void GameMenu()
    {
    string titulo = "🎮 Game Menu 🎮";
    string[] menu = {
        "1. 🕹️ Play",
        "2. 📜 View Game Rules",
        "3. 🗺️ View Maps",
        "4. 👥 View Character Information",
        "5. 🚪 Exit"
    };

    DecoracionUtils.MostrarConBordes(titulo, menu);
    }

    public static int GameMenuSelection()
    {
        GameMenu();
    
        bool validInput = true;
        DecoracionUtils.MostrarMensajeEstilado("🌟 Choose an option: (1-5) ");
        int opcion = Convert.ToInt32(Console.ReadLine());
    
        while (validInput)
        {
            if (opcion >= 1 && opcion <= 5)
            {
                validInput = false;
            }
            else
            {
                Console.WriteLine("❌ Invalid option.");
                DecoracionUtils.MostrarMensajeEstilado("🌟 Choose an option: (1-5) ");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
        }
    
        return opcion;
    }

    
}
