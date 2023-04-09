#pragma once
#include "DirectXFramework.h"
#include "CubeNode.h"
#include "SceneGraph.h"
#include "MeshNode.h"
#include "TerrainNode.h"

class Graphics2 : public DirectXFramework
{
public:
	void CreateSceneGraph();
	void UpdateSceneGraph();

};

