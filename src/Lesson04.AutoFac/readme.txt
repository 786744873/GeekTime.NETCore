��Autofac��ǿ�����������������������̣�AOP��������

ʲô�������Ҫ������������������
	�������Ƶ�ע��
	����ע��
	������
	���ڶ�̬����� AOP

.NET Core ����ע���ܺ�����չ��
	public interface IServiceProviderFactory<TContainerBuilder>

	����������ע���ܣ�����ʹ�������������Ϊ��չ�㣬���Լ�ע�뵽.NET Core�Ŀ����������
	Ҳ����˵��������ʹ�õ���������ע����ʱ������Ҫ��ע���ԵĹ��ܡ��ӿڵȣ�����ֻ��Ҫʹ�ùٷ����ĵĶ���Ϳ�������ʹ�á�

Autofac
	��װ���룺Autofac.Extensions.DependencyInjection��Autofac.Extras.DynamicProxy	
	�����������������Ϳ��Դﵽǰ������Ҫ����������

Program.cs ��
	UseServiceProviderFactory(new AutofacServiceProviderFactory)������������ע����������������

