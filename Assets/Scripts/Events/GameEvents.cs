
namespace Ducksten.SideScrollerTT.Events {
    //#TODO: Maybe remake that into EventSystem<> that would deal with events based on type of object given to it?
    //#TODO: Or just split events into few categories (input gameplay etc) and put them into appropriate static classes
    public static class GameEvents {
        public static SimpleGameEvent<int> onScoreUpdated = new();
        public static SimpleGameEvent onPlayerDied = new();
        public static SimpleGameEvent onGameOver = new();
    }
}
