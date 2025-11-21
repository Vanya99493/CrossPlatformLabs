import 'dart:convert';
import 'package:http/http.dart' as http;
import './IItem.dart';
import './product.dart';
import './user.dart';

class ApiService {

  static Future<List<IItem>> loadData() async {
    final productRes = await http.get(
      Uri.parse('https://dummyjson.com/products/category/smartphones'),
    );

    final userRes = await http.get(
      Uri.parse('https://dummyjson.com/users?limit=10'),
    );

    final productData = jsonDecode(productRes.body);
    final userData = jsonDecode(userRes.body);

    List<Product> products = (productData['products'] as List)
        .map((p) => Product.fromJson(p))
        .toList();

    List<User> users = (userData['users'] as List)
        .map((u) => User.fromJson(u))
        .toList();

    return [...products, ...users];


  }
}