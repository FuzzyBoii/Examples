#pragma once
#include "SceneNode.h"
#include <vector>
#include "DirectXFramework.h"
#include "WICTextureLoader.h"

class CubeNode : public SceneNode
{
	public:
		CubeNode() :SceneNode(L"default") 
		{
			_textureFile = L"Wood.bmp";
		};
		CubeNode(wstring name) :SceneNode(name) 
		{
			_textureFile = L"Wood.bmp";
		};

		bool Initialise(void) override;
		void Render(void) override;
		void Shutdown(void) override;
		void BuildGeometryBuffers();
		void BuildShaders();
		void BuildVertexLayout();
		void BuildConstantBuffer();
		void BuildTexture();
		
		
		
		ComPtr<ID3D11Buffer>			_vertexBuffer;
		ComPtr<ID3D11Buffer>			_indexBuffer;
		ComPtr<ID3DBlob>				_vertexShaderByteCode = nullptr;
		ComPtr<ID3DBlob>				_pixelShaderByteCode = nullptr;
		ComPtr<ID3D11VertexShader>		_vertexShader;
		ComPtr<ID3D11PixelShader>		_pixelShader;
		ComPtr<ID3D11InputLayout>		_layout;
		ComPtr<ID3D11Buffer>			_constantBuffer;
		ComPtr<ID3D11ShaderResourceView> _texture;;
		ComPtr<ID3D11Device>			_device;
		ComPtr<ID3D11DeviceContext>		_deviceContext;
		wstring							_textureFile;

	private:
};