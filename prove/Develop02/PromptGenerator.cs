using System.Runtime.InteropServices.Marshalling;

class PromptGenerator{

// 50 journaling prompts (generated by ChatGPT)
string[] _prompts = new string[]
{
    "Reflect on a moment from today that brought you joy and describe it in detail.",
    "Explore a recent challenge you faced and how you overcame it or what you learned from it.",
    "Write about a goal you're currently working towards and the progress you've made.",
    "Describe the emotions you felt during a significant conversation you had today.",
    "List three things you're grateful for and explain why they bring you joy.",
    "Share a memory from your past that still holds significance for you.",
    "Write about a book, article, or podcast you recently enjoyed and its impact on you.",
    "Explore a dream you had recently and try to decipher its meaning for you.",
    "Reflect on a mistake you made today and consider what you can learn from it.",
    "Write a letter to your future self, sharing your hopes and aspirations.",
    "Document the small, everyday moments that brought you happiness today.",
    "Explore a skill or hobby you're currently trying to improve and your progress.",
    "Share your thoughts on a current event or news story that caught your attention.",
    "Describe the sights, sounds, and smells of your surroundings at a particular moment.",
    "Reflect on a friendship and the role it plays in your life.",
    "Write about a fear or challenge you're facing and your plan for overcoming it.",
    "Explore your thoughts on a personal value or belief and how it guides your actions.",
    "Share a piece of advice you recently received and how it resonated with you.",
    "Write about a recent accomplishment, no matter how small, and celebrate it.",
    "Explore a goal or dream that you haven't yet pursued and why it matters to you.",
    "Describe a moment of self-discovery you experienced recently.",
    "Reflect on your self-care routine and whether any adjustments are needed.",
    "Write about a place you'd love to visit and what you hope to experience there.",
    "Explore your thoughts on a current trend or popular culture phenomenon.",
    "Share a quote that inspires you and explain its significance in your life.",
    "Document a conversation you had today that left a lasting impression on you.",
    "Explore your feelings about a recent change in your life and how you're adapting.",
    "Write about a skill or talent you admire in others and your journey to develop it.",
    "Reflect on a childhood memory that still influences your thoughts or actions.",
    "Share your thoughts on a recent act of kindness you witnessed or experienced.",
    "Explore the role of technology in your life and how it affects your daily routines.",
    "Write a letter to someone you appreciate but haven't expressed gratitude to lately.",
    "Describe a moment when you felt truly at peace with yourself and your surroundings.",
    "Explore your current priorities and how well they align with your long-term goals.",
    "Write about a personal habit you're trying to cultivate or break, and your progress.",
    "Reflect on a recent setback and the lessons you can draw from the experience.",
    "Share your thoughts on a favorite quote and how it resonates with your life.",
    "Explore your relationship with time and whether you feel balanced in its management.",
    "Document a dream or aspiration you've had since childhood and your progress.",
    "Write about a skill or hobby you'd like to learn in the near future and why.",
    "Reflect on your morning routine and its impact on the rest of your day.",
    "Explore your attitude towards failure and how it shapes your pursuit of goals.",
    "Write about a moment when you felt proud of your character or integrity.",
    "Share your thoughts on a recent movie, TV show, or piece of art that moved you.",
    "Reflect on a personal mantra or affirmation that guides you in challenging times.",
    "Explore the role of humor in your life and moments that made you laugh today.",
    "Write about a place that holds sentimental value for you and why it's significant.",
    "Reflect on a decision you made recently and its impact on your life.",
    "Describe a skill or talent you possess that you're proud of and how you developed it.",
    "Explore your relationship with nature and any recent experiences in the outdoors."
};

    // Select a random prompt
    public string GetRandomPrompt()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Length);
        return _prompts[index];
    }





}