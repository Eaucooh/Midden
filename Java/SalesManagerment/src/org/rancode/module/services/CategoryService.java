package org.rancode.module.services;

import java.util.List;

import org.rancode.module.entity.Category;

public interface CategoryService {

	//列出所有商品种类
	public List<Category> selectAll() throws Exception;

}
