#include "Graphics2.h"


Graphics2 app;

void Graphics2::CreateSceneGraph()
{
	SceneGraphPointer sceneGraph = GetSceneGraph();
	GetCamera()->SetCameraPosition(0.0f, 300.0f, -500.0f);
	// This is where you add nodes to the scene graph
	shared_ptr<MeshNode> node = make_shared<MeshNode>(L"Plane1", L"Plane\\Bonanza.3DS");
	node->SetWorldTransform(XMMatrixRotationAxis(XMVectorSet(1.0f, 0.1f, 0.0f, 0.0f), 90 * XM_PI / 180.0f)* XMMatrixTranslation(0.0f, 150.0f, 0.0f));
	sceneGraph->Add(node);
	shared_ptr<TerrainNode> terrain = make_shared<TerrainNode>(L"terrain");
	sceneGraph->Add(terrain);
	SetBackgroundColour(XMFLOAT4(0.4f, 0.5f, 0.9f, 1.0f));

}

void Graphics2::UpdateSceneGraph()
{
	SceneGraphPointer sceneGraph = GetSceneGraph();
	if (GetAsyncKeyState(0x57) < 0)
	{
		GetCamera()->SetForwardBack(1);
	}
	if (GetAsyncKeyState(0x53) < 0)
	{
		GetCamera()->SetForwardBack(-1);
	}
	if (GetAsyncKeyState(0x44) < 0)
	{
		GetCamera()->SetYaw(1);
	}
	if (GetAsyncKeyState(0x41) < 0)
	{
		GetCamera()->SetYaw(-1);
	}

	// This is where you make any changes to the local world transformations to nodes
	// in the scene graph
}
