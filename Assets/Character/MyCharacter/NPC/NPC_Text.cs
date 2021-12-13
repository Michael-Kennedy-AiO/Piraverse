public class NPC_Text{

    public static int textIndex = 1;
    public static string getText(int index){
        switch (index){
            case 1: return "Welcome to my bar captian what bring you here?";
            case 2: return "Suck gorgoes you are, here is your beer enjoy cái monement này đi";
            case 3: return "Thansk for visit Priraty Bar, come again";
            case 4: return "Your chest has 1,500.000 PIRA coins";
            case 5: return "Do you need anything else?";
            default: textIndex = 1; return "Not found";
        }
    }

}
