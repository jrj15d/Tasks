Tasks
=====

Task
----

Tasks are the base class for inherited tasks. They contain the most basic data that represents a task.

ProgressTask
------------

Progress Tasks represent a task that is meant to be completed over a period of time e.g. gain 10 pounds, learn a programming language, etc.

SingleTask
----------

Single Tasks represent a one-off task that is meant to be completed immediately e.g. clean my room, pay my bills, etc.


Models
------

- Task
	- Id (Guid)
	- Title (String)
	- Description (String)

- ProgressTask : Task
	- Start Date (DateTime)
	- End Date (DateTime)
	- Progress (Float)
