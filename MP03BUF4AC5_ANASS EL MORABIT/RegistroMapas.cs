using System.Collections.Generic;

public static class RegistroMapas
{
    public static List<Mapa> Mapas { get; private set; } = new List<Mapa>();

    static RegistroMapas()
    {
        InicializarMapas();
    }

    private static void InicializarMapas()
    {
       Mapas.Add(new Mapa("The Forgotten Forest", 
    "🌟 Welcome to the Forgotten Forest! 🌲\n\n" +
    "You find yourself in the heart of a dense, enchanted woodland shrouded in mist. This ancient forest is filled with secrets, where forgotten ruins and the whispers of the past lie hidden beneath the towering trees.\n\n" +
    "As you wander through its mystical groves, you begin to sense an ancient power at work, waiting for those brave enough to uncover it. However, danger lurks behind every shadow, and not all is as it seems.\n\n" +
    "- Upon reaching this mystical realm, your skills have been honed by the forest's magic, making you stronger and more capable of facing future challenges.\n" +
    "- Your level has increased, providing you with new abilities and resilience to tackle whatever lies ahead.\n\n" +
    "Continue your journey through the Forgotten Forest, where the path to greatness is filled with both peril and promise.", 
    6));



        Mapas.Add(new Mapa("The Caves of Eternity", 
    "🌟 Welcome to the Caves of Eternity! 🌌\n\n" +
    "Deep beneath the earth lies a labyrinth of ancient caves, their walls glowing with mysterious crystals. This expansive underground network is filled with perilous traps, relics of a long-lost civilization, and secrets waiting to be uncovered.\n\n" +
    "The deeper you explore, the more the very air seems to hum with magic, an energy that empowers those who are brave enough to face the darkness. But with each step, the danger increases. Only the boldest adventurers will survive its trials.\n\n" +
    "- As you venture deeper into these caverns, your experience has sharpened, and your abilities have grown stronger. You are now more resilient and better equipped to face the growing threats.\n" +
    "- Your level has increased, unlocking new powers and making you even more formidable in combat.\n\n" +
    "Press forward, adventurer, and uncover the mysteries hidden within the Caves of Eternity, where only the strongest survive.", 
    5));


        Mapas.Add(new Mapa("The Abandoned Kingdom", 
    "🌟 Congratulations, brave adventurer! 🌟\n\n" +
    "Your journey has brought you to the legendary Map 3—the crumbling remains of a once-great empire, now overrun by the relentless march of nature and haunted by the lingering spirits of its past.\n\n" +
    "This forsaken land stands as a testament to glory long lost and the unyielding power of time. Yet, in its ruins lie both peril and promise, daring only the strongest to venture forth.\n\n" +
    "- Your skills have been enhanced, sharpening your edge against the dangers that lurk in the shadows.\n" +
    "- Your level has increased, elevating you to new heights of strength and wisdom.\n\n" +
    "Beware, hero, for the spirits of this realm do not rest easily. Greater challenges and even greater rewards await you in this haunted wilderness.\n\n" +
    "🔥 Forge ahead, write your legend, and reclaim the glory that was lost!", 
    1));

    }

}
