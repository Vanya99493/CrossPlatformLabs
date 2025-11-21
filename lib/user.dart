import 'package:lab1/IItem.dart';

class User implements IItem {
  final int id;
  final String name;
  final int age;
  final String email;

  User({
    required this.id,
    required this.name,
    required this.age,
    required this.email,
  });

  factory User.fromJson(Map<String, dynamic> json) {
    return User(
      id: json['id'],
      name: json['firstName'],
      age: json['age'],
      email: json['email'],
    );
  }
}