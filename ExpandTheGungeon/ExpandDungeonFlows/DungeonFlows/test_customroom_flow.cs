﻿using ExpandTheGungeon.ExpandObjects;
using Dungeonator;
using System.Collections.Generic;
using UnityEngine;

namespace ExpandTheGungeon.ExpandDungeonFlows {

    public class test_customroom_flow : ExpandDungeonFlow {
        
        public static DungeonFlow Test_CustomRoom_Flow() {

            DungeonFlow m_CachedFlow = ScriptableObject.CreateInstance<DungeonFlow>();

            DungeonFlowNode entranceNode = GenerateDefaultNode(m_CachedFlow, PrototypeDungeonRoom.RoomCategory.ENTRANCE, ExpandPrefabs.elevator_entrance);
            DungeonFlowNode exitNode = GenerateDefaultNode(m_CachedFlow, PrototypeDungeonRoom.RoomCategory.EXIT, ExpandRoomPrefabs.SecretExitRoom);
            DungeonFlowNode bossfoyerNode = GenerateDefaultNode(m_CachedFlow, PrototypeDungeonRoom.RoomCategory.SPECIAL, overrideTable: ExpandPrefabs.boss_foyertable);
            DungeonFlowNode bossNode = GenerateDefaultNode(m_CachedFlow, PrototypeDungeonRoom.RoomCategory.BOSS, ExpandRoomPrefabs.GungeoneerMimicBossRoom);
            
            DungeonFlowNode TestRoomNode_01 = GenerateDefaultNode(m_CachedFlow, PrototypeDungeonRoom.RoomCategory.NORMAL, ExpandRoomPrefabs.Expand_Apache_RickRollChest);

            DungeonFlowNode TestShopNode = GenerateDefaultNode(m_CachedFlow, ExpandPrefabs.shop02.category, overrideTable: ExpandPrefabs.shop_room_table);
            DungeonFlowNode TestRewardNode = GenerateDefaultNode(m_CachedFlow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ExpandPrefabs.gungeon_rewardroom_1);
            
            DungeonFlowNode TestSecretRoomNode = GenerateDefaultNode(m_CachedFlow, PrototypeDungeonRoom.RoomCategory.SECRET, ExpandRoomPrefabs.Expand_GlitchedSecret);
            DungeonFlowNode testConnectorNode01 = GenerateDefaultNode(m_CachedFlow, PrototypeDungeonRoom.RoomCategory.NORMAL, ExpandRoomPrefabs.Expand_CorridorOfDoom);

            DungeonFlowNode RickRollRewardNode = GenerateDefaultNode(m_CachedFlow, PrototypeDungeonRoom.RoomCategory.SECRET, ExpandRoomPrefabs.Expand_Secret_Falsechest);

            m_CachedFlow.name = "Test_CustomRoom_Flow";
            m_CachedFlow.fallbackRoomTable = null;
            m_CachedFlow.phantomRoomTable = null;
            m_CachedFlow.subtypeRestrictions = new List<DungeonFlowSubtypeRestriction>(0);
            m_CachedFlow.flowInjectionData = new List<ProceduralFlowModifierData>(0);
            m_CachedFlow.sharedInjectionData = new List<SharedInjectionData>(0);
            m_CachedFlow.Initialize();

            m_CachedFlow.AddNodeToFlow(entranceNode, null);            
            m_CachedFlow.AddNodeToFlow(TestRoomNode_01, entranceNode);
            
            m_CachedFlow.AddNodeToFlow(TestRewardNode, TestRoomNode_01);
            m_CachedFlow.AddNodeToFlow(TestShopNode, TestRoomNode_01);
            m_CachedFlow.AddNodeToFlow(RickRollRewardNode, TestShopNode);

            m_CachedFlow.AddNodeToFlow(TestSecretRoomNode, TestRewardNode);

            m_CachedFlow.AddNodeToFlow(testConnectorNode01, TestRoomNode_01);

            m_CachedFlow.AddNodeToFlow(bossfoyerNode, testConnectorNode01);
            m_CachedFlow.AddNodeToFlow(bossNode, bossfoyerNode);
            m_CachedFlow.AddNodeToFlow(exitNode, bossNode);

            m_CachedFlow.FirstNode = entranceNode;

            return m_CachedFlow;
        }
    }
}

