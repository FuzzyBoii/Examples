#include "SceneGraph.h"

bool SceneGraph::Initialise(void)
{
    for (int i = 0; i < _children.size(); i++)
    {
        if(_children[i]->Initialise() == false) 
        { 
            return false; 
        }
    }
    return true;
}

void SceneGraph::Update(FXMMATRIX& currentWorldTransformation)
{
    SceneNode::Update(currentWorldTransformation);
    FXMMATRIX& combined = XMLoadFloat4x4(&_combinedWorldTransformation);
    for (int i = 0; i < _children.size(); i++)
    {
        _children[i]->Update(combined);
    }
}

void SceneGraph::Render(void)
{
    for (int i = 0; i < _children.size(); i++)
    {
        _children[i]->Render();
    }
}

void SceneGraph::Shutdown(void)
{
    for (int i = 0; i < _children.size(); i++)
    {
        _children[i]->Shutdown();
    }
}

void SceneGraph::Add(SceneNodePointer node)
{
    _children.push_back(node);
}

void SceneGraph::Remove(SceneNodePointer node)
{
    for (int i = 0; i < _children.size(); i++)
    {
        if (_children[i] == node)
        {
            _children[i].get()->Remove(node);
            _children.erase(_children.begin() + i);
        }
    }   
}

SceneNodePointer SceneGraph::Find(wstring name)
{
    for (int i = 0; i < _children.size(); i++)
    {
        if (_children[i].get()->Find(name) != nullptr)
        {
            return _children[i];
        }
    }
    return nullptr;
}
