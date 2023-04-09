#pragma once
#include "SceneNode.h"
#include "DirectXFramework.h"
#include "MeshRenderer.h"
#include "ResourceManager.h"
#include "WICTextureLoader.h"
#include <fstream>
class TerrainNode : public SceneNode
{
public:
	TerrainNode() :SceneNode(L"default")
	{
		_heightMapFile = L"Example_HeightMap.raw";
		_textureFile = L"white.png";
	};
	TerrainNode(wstring name) :SceneNode(name)
	{
		_heightMapFile = L"Example_HeightMap.raw";
		_textureFile = L"white.png";
	};

	bool Initialise();
	void Render();
	void Shutdown();
	void BuildGeometryBuffers();
	void BuildShaders();
	void BuildVertexLayout();
	void BuildConstantBuffer();
	void BuildTexture();

	bool LoadHeightMap(wstring heightMapFilename);

	void BuildRendererStates();

private:
	ComPtr<ID3D11Buffer>			_vertexBuffer;
	ComPtr<ID3D11Buffer>			_indexBuffer;
	ComPtr<ID3DBlob>				_vertexShaderByteCode = nullptr;
	ComPtr<ID3DBlob>				_pixelShaderByteCode = nullptr;
	ComPtr<ID3D11VertexShader>		_vertexShader;
	ComPtr<ID3D11PixelShader>		_pixelShader;
	ComPtr<ID3D11InputLayout>		_layout;
	ComPtr<ID3D11Buffer>			_constantBuffer;
	ComPtr<ID3D11ShaderResourceView> _texture;
	ComPtr<ID3D11Device>			_device;
	ComPtr<ID3D11DeviceContext>		_deviceContext;
	ComPtr<ID3D11RasterizerState>   _defaultRasteriserState; 
	ComPtr<ID3D11RasterizerState>   _wireframeRasteriserState;
	wstring							_textureFile;
	vector<VERTEX>                  _terrainVertex;
	vector<UINT>                    _indicies;
	wstring                         _heightMapFile;
	vector<float>                   _heightValues;
	int								_numberOfXPoints = 1024;
	int								_numberOfZPoints = 1024;
	float                           _heightMapMultiplier = 250;

};

