package org.rancode.module.services.Impl;

import java.util.List;

import org.omg.PortableServer.SERVANT_RETENTION_POLICY_ID;
import org.rancode.module.dao.BaseDao;
import org.rancode.module.dao.Impl.BaseDaoImpl;
import org.rancode.module.entity.User;
import org.rancode.module.services.UserService;

public class UserServiceImpl implements UserService {
	
	//查询一条记录
	@Override
	public User selectOne(Object[] paraArray) throws Exception {
		User user = new User();
		BaseDaoImpl dao = new BaseDaoImpl();
		String sql = "select id,name,password,identity from user where name=? and password=?";
		List list = dao.select(sql, 4, paraArray);
		if (!list.isEmpty()) {
			user.setId((String) ((Object[]) list.get(0))[0]);
			user.setName((String) ((Object[]) list.get(0))[1]);
			user.setPassword((String) ((Object[]) list.get(0))[2]);
			user.setIdentity((String) ((Object[]) list.get(0))[3]);
			return user;
		}
		return null;
	}
	
	//通过Id修改用户
	@Override
	public int updateUserById(Object[] paraArray) throws Exception {
		int result = 0;
		BaseDaoImpl dao = new BaseDaoImpl();
		String sql = "update user set name = ?,password=? where id=?";
		result = dao.update(sql, paraArray);
		return result;
	}

}
