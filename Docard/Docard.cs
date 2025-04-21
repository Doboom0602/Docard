using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using Docard.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using GunBodyRecoilPatch;
using ZeroGBulletPatch;


namespace Docard
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("Root.Gun.bodyRecoil.Patch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.dk.rounds.plugins.zerogpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class Docard : BaseUnityPlugin
    {
        private const string ModId = "com.Doboom.rounds.Docard";
        private const string ModName = "Docard";
        public const string Version = "1.2.2"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "DC";

        public static Docard instance
        {
            get; private set;
        }
        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;
            CustomCard.BuildCard<ICBM>();
            CustomCard.BuildCard<SeekerBombs>();
            CustomCard.BuildCard<Juggernaut>();
        }
    }
}