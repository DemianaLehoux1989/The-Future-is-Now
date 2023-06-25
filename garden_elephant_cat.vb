Public Class ResourceService

	'Starting up a resource service for young entrepreneurs'
	
	Private _resourceList As List(Of Resource)
	
	Public Sub New()
		_resourceList = New List(Of Resource)
	End Sub
	
	Public Sub AddResource(resource As Resource)
		_resourceList.Add(resource)
	End Sub
	
	Public Sub RemoveResource(resource As Resource)
		_resourceList.Remove(resource)
	End Sub
	
	Public Function GetResources() As List(Of Resource)
		Return _resourceList
	End Function
	
End Class

Public Class Resource
	
	Private _name As String
	Private _description As String
	Private _url As String
	Private _category As ResourceCategory
	
	Public Sub New(name As String, description As String, url As String, category As ResourceCategory)
		_name = name
		_description = description
		_url = url
		_category = category
	End Sub
	
	Public Property Name As String
		Get
			Return _name
		End Get
		Set(value As String)
			_name = value
		End Set
	End Property
	
	Public Property Description As String
		Get
			Return _description
		End Get
		Set(value As String)
			_description = value
		End Set
	End Property
	
	Public Property URL As String
		Get
			Return _url
		End Get
		Set(value As String)
			_url = value
		End Set
	End Property
	
	Public Property Category As ResourceCategory
		Get
			Return _category
		End Get
		Set(value As ResourceCategory)
			_category = value
		End Set
	End Property
	
End Class

Public Enum ResourceCategory
	Finance
	Marketing
	Legal
	Mentorship
	Networking
End Enum

Public Class ResourceRepository
	
	Private _resourceList As List(Of Resource)
	
	Public Sub New()
		_resourceList = New List(Of Resource)
	End Sub
	
	Public Sub AddResource(resource As Resource)
		_resourceList.Add(resource)
	End Sub
	
	Public Sub RemoveResource(resource As Resource)
		_resourceList.Remove(resource)
	End Sub
	
	Public Function GetResources() As List(Of Resource)
		Return _resourceList
	End Function
	
End Class

Public Class ResourceManager
	
	Private _resourceService As ResourceService
	
	Public Sub New(resourceService As ResourceService)
		_resourceService = resourceService
	End Sub
	
	Public Sub AddResource(resource As Resource)
		_resourceService.AddResource(resource)
	End Sub
	
	Public Function GetResources() As List(Of Resource)
		Return _resourceService.GetResources()
	End Function
	
	Public Sub RemoveResource(resource As Resource)
		_resourceService.RemoveResource(resource)
	End Sub
	
End Class

Public Class ResourceViewModel
	
	Private _resource As Resource
	
	Public Sub New(resource As Resource)
		_resource = resource
	End Sub
	
	Public ReadOnly Property Name As String
		Get
			Return _resource.Name
		End Get
	End Property
	
	Public ReadOnly Property Description As String
		Get
			Return _resource.Description
		End Get
	End Property
	
	Public ReadOnly Property URL As String
		Get
			Return _resource.URL
		End Get
	End Property
	
	Public ReadOnly Property Category As ResourceCategory
		Get
			Return _resource.Category
		End Get
	End Property
	
End Class

Public Class ResourceController
	
	Private _resourceManager As ResourceManager
	
	Public Sub New(resourceManager As ResourceManager)
		_resourceManager = resourceManager
	End Sub
	
	Public Function Index() As List(Of ResourceViewModel)
		Dim resources = _resourceManager.GetResources()
		
		Dim resourceViewModels = New List(Of ResourceViewModel)
		For Each resource In resources
			Dim viewModel = New ResourceViewModel(resource)
			resourceViewModels.Add(viewModel)
		Next
		
		Return resourceViewModels
	End Function
	
	Public Sub AddResource(name As String, description As String, url As String, category As ResourceCategory)
		Dim resource As New Resource(name, description, url, category)
		_resourceManager.AddResource(resource)
	End Sub
	
	Public Sub RemoveResource(name As String)
		Dim resource As Resource = _resourceManager.GetResources().Where(Function(r) r.Name = name).FirstOrDefault()
		_resourceManager.RemoveResource(resource)
	End Sub
	
End Class