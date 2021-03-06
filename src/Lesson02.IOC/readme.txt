依赖注入 -- 良好架构的起点

为什么要使用依赖注入框架？
	借助依赖注入框架，我们可以轻松管理类之间的依赖，帮助我们再构建应用时遵循设计原则，确保代码的可维护性和可扩展性。
	ASP.NET Core的整个架构中，依赖注入是一等公民，内置的框架提供了对象创建和生命周期管理的核心能力，各个组件相互协作，也是由依赖注入框架的能力来实现的。

组件包
	Microsoft.Extensions.DependencyInjection.Abstractions
	Microsoft.Extensions.DependencyInjection
	这里，它用到了一个经典的设计模式，叫做接口实现分离模式，抽象包只包含接口的定义，具体的实现都在实现包中。
	那就意味着我们的组件只需要依赖它的抽象接口，而不需要依赖它的实现，在使用的时候注入它的具体实现即可。
	这样做，我们可以再使用时决定我们用具体哪个实现，未来我们可以去做任意的扩展去替换依赖注入框架的具体实现，比如内置的依赖注入框架、第三方的AutoFac等。

核心类型
	IServiceCollection
		负责服务的注册
	ServiceDescriptor
		每一个服务注册时的信息
	IServiceProvider
		具体的容器，也是由 ServiceCollection Build出来的。
	IServiceScope
		表示一个容器的子容器的生命周期
		
生命周期：ServiceLifetime
	单例 Singleton
		在整个我们根容器的生命周期内，都是单例，全局单例。
	作用域 Scoped
		在我的 Scope 的生存周期内，也就是容器的生存周期内、或者子容器的生存周期内，得到的是一个单例模式，容器释放时，对象也会随之释放。
		简单的可以理解为：在每一次请求内得到的都是同一个对象，不同请求之间，得到的对象实例是不同的。
	瞬时（暂时） Transient
		每一次从容器里获取对象时，都会得到一个全新的对象。

Controller 中使用注入时，有两种方式：
	构造函数注入
	Action 参数中 [FromServices]IMySingletonService singletonService1
	当需要使用的对象是整个Controller中大部分函数中使用时，建议使用构造函数方式注入。
	反之，则建议仅在需要使用的接口/函数中，使用 FromServices 标记获取对象。