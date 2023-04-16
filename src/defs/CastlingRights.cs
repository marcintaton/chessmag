namespace chessmag.src.defs
{
    // 0000 - each bit for one right
    public enum CastlingRights : int
    {
        NONE = 0,
        WK = 1,
        WQ = 2,
        BK = 4,
        BQ = 8,
        ALL = 15
    }
}